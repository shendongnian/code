    public abstract class DataAccessLayerBase
    {
        protected string GetXml(string storedProcedureName, OutputType outputType, params Tuple<string,DBType,object>[] parameters)
        {
            StringBuilder sb = new StringBuilder();
            //  Get the associated members based upon the criteria  
            Database db = DatabaseFactory.CreateDatabase("MyDatabase");  
            using(DbCommand cmd = db.GetStoredProcCommand(storedProcedureName))
            {
                foreach(var parameter in parameters)
                {
                    db.AddInParameter(cmd, parameter.Item1, parameter.Item2, parameter.Item3);
                }
 
                using(IDataReader dr = db.ExecuteReader(cmd))
                {
                    while (dr.Read())  
                    {  
                        sb.Append(dr.GetValue(0));  
                    }  
                }      
                switch(outputType)
                {
                    case OutputType.Xml:
                        return sb.ToString();  
                    case OutputType.Json:
                        XmlDocument xdoc = new XmlDocument();  
                        xdoc.LoadXml(sb.ToString());  
                        return JsonConvert.SerializeXmlNode(xdoc);  
                    default:
                        throw new NotSupportedException(); // Some sort of error.
                }
            }
        } 
    }
