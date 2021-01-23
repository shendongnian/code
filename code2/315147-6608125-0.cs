    <#@ template language="C#" debug="false" hostspecific="true"#>
    <#@ include file="EF.Utility.CS.ttinclude"#><#@
     output extension=".cs"#><#
    // Copyright (c) Microsoft Corporation.  All rights reserved.
    
    CodeGenerationTools code = new CodeGenerationTools(this);
    MetadataLoader loader = new MetadataLoader(this);
    CodeRegion region = new CodeRegion(this, 1);
    MetadataTools ef = new MetadataTools(this);
    
    string inputFile = @"D:\Projects\Empresa\CTM_Empresa\trunk\CTM.Empresa.Logic\DataModel\CTM.Empresa.Database.edmx";
    
    string entityName = @"Email";
    
    bool printNavigationLists = false;
    
    MetadataWorkspace metadataWorkspace = null;
    bool allMetadataLoaded = loader.TryLoadAllMetadata(inputFile, out metadataWorkspace);
    EdmItemCollection ItemCollection = (EdmItemCollection)metadataWorkspace.GetItemCollection(DataSpace.CSpace);
    
    string namespaceName = code.VsNamespaceSuggestion();
    
    EntityFrameworkTemplateFileManager fileManager = EntityFrameworkTemplateFileManager.Create(this);
    
    RecursiveEntityProcessor.code = code;
    RecursiveEntityProcessor.ItemCollection = ItemCollection;
    RecursiveEntityProcessor.metaData = ef;
    
    // Emit Entity Types
    foreach (EntityType entity in ItemCollection.GetItems<EntityType>().Where(it => it.Name == entityName))
    {
        fileManager.StartNewFile(entity.Name + ".cs");
    	
    	var result = new List<PropertyCustomData>();	
    
    	RecursiveEntityProcessor.GetEntityPropertyNames(result, entity.Name , 2 , "");	
    	
        //WriteEntityTypeSerializationInfo(entity, ItemCollection, code, ef);
    #>
    <#=Accessibility.ForType(entity)#> <#=code.SpaceAfter(code.AbstractOption(entity))#>class <#=code.Escape(entity)#><#=code.StringBefore(" : ", code.Escape(entity.BaseType))#>
    {
    <# 
        foreach (PropertyCustomData property in result)
        {		
    		#>
    	/// <summary>
        /// Gets or sets <#=code.Escape(property.PropertyName)#>.
        /// </summary>
        <#=Accessibility.ForProperty(property.PropertyDefenition)#> <#=code.Escape(property.PropertyDefenition.TypeUsage)#> <#=code.Escape(property.PropertyName)#> { get; set; }
    <#
    		
        }    
    }#>	
    }
    
    <#+ 
    
    	public class PropertyCustomData
        {
            public EdmProperty PropertyDefenition { get; set; }
    
            public string PropertyName { get; set; }
        }
    	
    	public static class RecursiveEntityProcessor
        {		
    		public static CodeGenerationTools code;
    		
    		public static EdmItemCollection ItemCollection;
    		
    		public static MetadataTools metaData;
    
            public static EntityType FindByName(string entityName)
            {
                return ItemCollection.GetItems<EntityType>().Single(it => it.Name == entityName);
            }
    
            public static void GetEntityPropertyNames(IList<PropertyCustomData> result, string entityName, int recursiveDepth, string currentPrefix, bool canPrintPrimaryKeys = true)
            {			
    			if (recursiveDepth > 0 )
    			{
    	            EntityType entity = FindByName(entityName);
    
    	            foreach (EdmProperty edmProperty in entity.Properties.Where(p => p.TypeUsage.EdmType is PrimitiveType && p.DeclaringType == entity))
    	            {
    					if (metaData.IsKey(edmProperty) && !canPrintPrimaryKeys)
    					{
    						continue;
    					}
    					
    	                result.Add(new PropertyCustomData { PropertyDefenition = edmProperty, PropertyName = currentPrefix + code.Escape(edmProperty) });
    	            }
    
    	            foreach (NavigationProperty navProperty in entity.NavigationProperties.Where(np => np.DeclaringType == entity))
    	            {
    	                if (navProperty.ToEndMember.RelationshipMultiplicity != RelationshipMultiplicity.Many)
    	                {
    	                    string childEntityName = navProperty.ToEndMember.GetEntityType().Name;
    
    	                    GetEntityPropertyNames(result, childEntityName, recursiveDepth - 1, currentPrefix + code.Escape(navProperty), false);
    	                }
    	            }
    			}
            }
        }
    
    #>
