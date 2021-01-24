    internal class ManageDataTypeBuilder
    { 
    public IEnumerable<IDataType> DataTypes{ get; set; }
    public ManageDataTypeBuilder()
    {
        // add all datatypes to DataTypes ienumerable here
    }
    public void BuildDataType(DataType type)
    {
        var dataType = DataTypes.FirstOrDefault(b => b.Type == type);
        if(dataType == null)
        {
            throw new Exception("No Datatype set");
        }else{
            type.DoActivity();
        }
    }
    }
