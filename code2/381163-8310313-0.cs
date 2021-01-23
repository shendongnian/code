    // make the class generic
    public class DataGridColumnData<TSearch, TResult>
    {
        public TSearch SearchColumn { get; set; }
        public TResult ResultColumn { get; set; }
    }
    
    // create a factory method that will create a statically typed version
    // based on the types given as input
    private static object GetDataGridColumnData(Type searchType, Type resultType)
    {
        var typedColumnDataType = typeof(DataGridColumnData<,>)
            .MakeGenericType(new[] { searchType, resultType});
        return Activator.CreateInstance(typedColumnDataType);
    }
    // use the factory method to create instances
    object instance = GetDataGridColumnData(
        Type.GetType("System.Int32"), 
        Type.GetType("System.String"));
