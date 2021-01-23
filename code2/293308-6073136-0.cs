     public class SPParamCollection : List<SPParams>
        {
        
        }
        public struct SPParams
        {
            public string Name { get; set; }
            public object   Value { get; set; }
            public SqlDbType SqlDbType { get; set; }
        
        }
    public void AddSomethingToDatabase(SPParamCollection arrParam)
            {
              foreach (SPParams param in arrParam)
              cmd.Parameters.Add(param.Name, param.Value);
            }    
