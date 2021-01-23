    public interface ISample
    {
        object KOD {get;set;} 
    }
    void SetNewRecord<T>() where T : ISample
    {
         var list = GridView.DataSource as IEnumerable<T>;
         // implement needed logic here
    }
