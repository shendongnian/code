        public class SomeInvoiceData
        {
                public int InvoiceID { get; set; }
                public System.DateTime InvoiceDate { get; set; }
                public string InvoiceName { get; set; }
        }
        
        public static class Value
        {
                public static string Formatted(this object o) 
                {
                        if (o is string)
                        {
                                return $"'{o.ToString()}'";
                        }
                        else if(o is DateTime)
                        {
                                return $"'{o.ToString()}'";
                        }
                        else
                        {
                                return $"{o.ToString()}";
                        }
                }
        }
        
		
        public class SQLBuilder
        {
                private List<string> List = new List<string>();
                private string Delimiter = ",";
                public void AppendAll(object instance)
                {
                        System.Reflection.PropertyInfo[] listProperty = instance.GetType().GetProperties();
                        foreach (var property in listProperty)
                        {
                                var pvalue = property.GetValue(instance);
                                var statement = $"{property.Name} = {pvalue.Formatted()}";
                                List.Add(statement);
                        }
                }
                public string Get()
                {
                        return String.Join(Delimiter, List);
                }
        }
		
	
