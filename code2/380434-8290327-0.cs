    /// <summary>
    /// The base part collection
    /// </summary>
    /// <remarks></remarks>
    public class PartBase
    {
    	/// <summary>
    	/// The key for the record, such as a recordid
    	/// </summary>
    	/// <value></value>
    	/// <returns></returns>
    	/// <remarks></remarks>
    	public virtual string CollectionKey {get; set;}
    
    	public PartBase() : base()
    	{
    		m_cParts = new PartBaseCollections();
    	}
    
    	public virtual void InitializeFromDataRow(DataRow oRow)
    	{
    		// ToDo: Either implement generic column/datarow mapping through reflection or have each class override this method
    	}
    
    	private PartBaseCollections m_cParts;
    
    	public PartBaseCollections Parts
    	{
    		get
    		{
    			return m_cParts;
    		}
    	}
    
    	public PartBaseCollection GetParts(string sTableName)
    	{
    		if (this.Parts.Contains(sTableName))
    		{
    			return this.Parts(sTableName);
    		}
    		else
    		{
    			PartBaseCollection cParts = new PartBaseCollection(sTableName);
    			this.Parts.Add(cParts);
    			return cParts;
    		}
    	}
    
    	public void AddParts(DataSet dsData)
    	{
    
    		foreach (DataTable oTable in dsData.Tables)
    		{
    			PartBaseCollection cParts = null;
    
    			cParts = GetParts(oTable.TableName);
    
    			cParts.AddRecordsFromTable(oTable);
    		}
    	}
    
    }
    
    /// <summary>
    /// A collection of PartBases keyed by a value, such as a table name (for example, Pistons)
    /// </summary>
    /// <remarks></remarks>
    public class PartBaseCollection : System.Collections.ObjectModel.KeyedCollection<string, PartBase>
    {
    
    	public string CollectionKey {get; set;}
    	public Type RecordType {get; set;}
    
    	public PartBaseCollection(string TableName)
    	{
    		this.CollectionKey = TableName;
    		// Assume that the TableName is a class in the current namespace
    		RecordType = Type.GetType(this.GetType().Namespace + "." + TableName, false, true);
    	}
    
    	protected override string GetKeyForItem(PartBase item)
    	{
    		return item.CollectionKey;
    	}
    
    	public PartBase ManufactureRecord()
    	{
    		return Activator.CreateInstance(this.RecordType);
    	}
    
    	public void AddRecordsFromTable(DataTable oTable)
    	{
    
    		foreach (DataRow oRow in oTable.Rows)
    		{
    			PartBase oPart = null;
    
    			oPart = ManufactureRecord();
    			oPart.InitializeFromDataRow(oRow);
    
    			this.Add(oPart);
    		}
    	}
    }
    
    /// <summary>
    /// All of the PartBaseCollection elements for a given PartBase
    /// </summary>
    /// <remarks></remarks>
    public class PartBaseCollections : System.Collections.ObjectModel.KeyedCollection<string, PartBaseCollection>
    {
    
    	protected override string GetKeyForItem(PartBaseCollection item)
    	{
    		return item.CollectionKey;
    	}
    }
    
    public class Engine : PartBase
    {
    
    }
    
    public class Piston : PartBase
    {
    
    }
