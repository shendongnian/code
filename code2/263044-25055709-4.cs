    Option Infer On
    Imports System.Xml.Linq
    
    ''' <summary>
    ''' This class allows one to convert between an EF conceptual model's entity/property pair
    ''' and its database store's table/column pair.
    ''' </summary>
    ''' <remarks>It takes into account entity splitting and complex-property designations;
    ''' it DOES NOT take into account inherited properties
    ''' (in such a case, you should access the entity's base class)</remarks>
    Public Class MSLMappingAction
    
    '   private fields and routines
    Private mmaMSLMapping As XElement
    Private mmaModelName As String
    Private mmaNamespace As String
    
    Private Function FullElementName(ByVal ElementName As String) As String
    '   pre-pend Namespace to ElementName
    Return "{" & mmaNamespace & "}" & ElementName
    End Function
    
    Private Sub ValidateParams(ByVal MappingXML As XElement, Byval ModelName As String)
    '   verify that model name is specified
    If String.IsNullOrEmpty(ModelName) Then
    	Throw New EntityException("Entity model name is not given!")
    End If
    '   verify that we're using C-S space
    If MappingXML.@Space <> "C-S" Then
    	Throw New MetadataException("XML is not C-S mapping data!")
    End If
    '   get Namespace and set private variables
    mmaNamespace = MappingXML.@xmlns
    mmaMSLMapping = MappingXML : mmaModelName = ModelName
    End Sub
    
    '   properties
    ''' <summary>
    ''' Name of conceptual entity model
    ''' </summary>
    ''' <returns>Conceptual-model String</returns>
    ''' <remarks>Model name can only be set in constructor</remarks>
    Public ReadOnly Property EntityModelName() As String
    Get
    	Return mmaModelName
    End Get
    End Property
    
    ''' <summary>
    ''' Name of mapping namespace
    ''' </summary>
    ''' <returns>Namespace String of C-S mapping layer</returns>
    ''' <remarks>This value is determined when the XML mapping
    ''' is first parsed in the constructor</remarks>
    Public ReadOnly Property MappingNamespace() As String
    Get
    	Return mmaNamespace
    End Get
    End Property
    
    '   constructors
    ''' <summary>
    ''' Get C-S mapping information for an entity model (with XML tree)
    ''' </summary>
    ''' <param name="MappingXML">XML mapping tree</param>
    ''' <param name="ModelName">Conceptual-model name</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal MappingXML As XElement, ByVal ModelName As String)
    ValidateParams(MappingXML, ModelName)
    End Sub
    
    ''' <summary>
    ''' Get C-S mapping information for an entity model (with XML file)
    ''' </summary>
    ''' <param name="MSLFile">MSL mapping file</param>
    ''' <param name="ModelName">Conceptual-model name</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal MSLFile As String, ByVal ModelName As String)
    Dim MappingXML As XElement = XElement.Load(MSLFile)
    ValidateParams(MappingXML, ModelName)
    End Sub
    
    '   methods
    ''' <summary>
    ''' Get C-S mapping infomration for an entity model (with XML String)
    ''' </summary>
    ''' <param name="XMLString">XML mapping String</param>
    ''' <param name="ModelName">Conceptual-model name</param>
    ''' <returns></returns>
    Public Shared Function Parse(ByVal XMLString As String, ByVal ModelName As String)
    Return New MSLMappingAction(XElement.Parse(XMLString), ModelName)
    End Function
    
    ''' <summary>
    ''' Convert conceptual entity/property information into store table/column information
    ''' </summary>
    ''' <param name="ConceptualInfo">Conceptual-model data
    ''' (.EntityName = entity expression String, .PropertyName = property expression String)</param>
    ''' <returns>Store data (.TableName = table-name String, .ColumnName = column-name String)</returns>
    ''' <remarks></remarks>
    Public Function ConceptualToStore(ByVal ConceptualInfo As MSLConceptualInfo) As MSLStoreInfo
    Dim StoreInfo As New MSLStoreInfo
    With ConceptualInfo
    	'   prepare to query XML
    	If Not .EntityName.Contains(".") Then
    		'   make sure entity name is fully qualified
    		.EntityName = mmaModelName & "." & .EntityName
    	End If
    	'   separate property names if there's complex-type nesting
    	Dim Properties() As String = .PropertyName.Split(".")
    	'   get relevant mapping fragments
    	Dim MappingInfo As IEnumerable(Of XElement) = _					
    		(From mi In mmaMSLMapping.Descendants(FullElementName("EntityTypeMapping")) _
    			Where mi.@TypeName = "IsTypeOf(" & .EntityName & ")" _
    				OrElse mi.@TypeName = .EntityName _
    		 Select mi)
    	Dim MappingFragments As IEnumerable(Of XElement) = _
    		(From mf In MappingInfo.Descendants(FullElementName("MappingFragment")) _
    		 Select mf)
    	'   make sure entity is in model
    	If MappingInfo Is Nothing _
    			OrElse MappingInfo.Count = 0 Then
    		Throw New EntityException("Entity """ & .EntityName & """ was not found!")
    	End If
    	'   search each mapping fragment for the desired property
    	For Each MappingFragment In MappingFragments
    		'   get physical table for this fragment
    		StoreInfo.TableName = MappingFragment.@StoreEntitySet
    		'   search property expression chain
    		Dim PropertyMapping As IEnumerable(Of XElement) = {MappingFragment}
    		'   parse complex property info (if any)
    		For index = 0 To UBound(Properties) - 1
    			'   go down	1 level
    			Dim ComplexPropertyName = Properties(index)
    			PropertyMapping = _
    				(From pm In PropertyMapping.Elements(FullElementName("ComplexProperty")) _
    					Where pm.@Name = ComplexPropertyName)
    			'   verify that the property specified for this level exists
    			If PropertyMapping Is Nothing _
    					OrElse PropertyMapping.Count = 0 Then
    				Exit For
    			End If
    		Next index
    		'   property not found? try next fragment
    		If PropertyMapping Is Nothing _
    				OrElse PropertyMapping.Count = 0 Then
    			Continue For
    		End If
    		'   parse scalar property info
    		Dim ScalarPropertyName = Properties(UBound(Properties))
    		Dim ColumnName As String = _
    			(From pm In PropertyMapping.Elements(FullElementName("ScalarProperty")) _
    				Where pm.@Name = ScalarPropertyName _
    				Select CN = pm.@ColumnName).FirstOrDefault
    		'   verify that scalar property exists
    		If Not String.IsNullOrEmpty(ColumnName) Then
    			'   yes? return (exit) with column info
    			StoreInfo.ColumnName = ColumnName : Return StoreInfo
    		End If
    	Next MappingFragment
    	'   property wasn't found
    	Throw New EntityException("Property """ & .PropertyName _
    		& """ of entity """ & .EntityName & """was not found!")
    End With
    End Function
    End Class
    
    ''' <summary>
    ''' Conceptual-model entity and property information  
    ''' </summary>
    Public Structure MSLConceptualInfo
    ''' <summary>
    ''' Name of entity in conceptual model
    ''' </summary>
    ''' <value>Entity expression String</value>
    ''' <remarks>EntityName may or may not be fully qualified (i.e., "ModelName.EntityName");
    ''' when a mapping method is called by the MSLMappingAction class, then
    ''' the conceptual model's name and a period will be pre-pended if it's omitted</remarks>
    Public Property EntityName As String
    ''' <summary>
    ''' Name of property in entity
    ''' </summary>
    ''' <value>Property expression String</value>
    ''' <remarks>PropertyName may be either a stand-alone scalar property or a scalar property
    ''' within 1 or more levels of complex-type properties; in the latter case, it MUST be fully
    ''' qualified (i.e., "ComplexPropertyName.InnerComplexPropertyName.ScalarPropertyName")</remarks>
    Public Property PropertyName As String
    End Structure
    
    ''' <summary>
    ''' Database-store table and column information
    ''' </summary>
    Public Structure MSLStoreInfo
    ''' <summary>
    ''' Name of table in database
    ''' </summary>
    Public Property TableName As String
    ''' <summary>
    ''' Name of column in database table
    ''' </summary>
    Public Property ColumnName As String
    End Structure
 
