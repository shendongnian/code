    public class SQLGeneralDB<T> : IMyDbInterface<T> where T : class, ISQLGeneralDB, new() 
    
  
    public interface IMyDbInterface<T> where T : class, ISQLGeneralDB, new() {
       List<T> ReadTable(string sqlcommand);
     }
