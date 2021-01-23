     public static dynamic DynamicWeirdness() {
        dynamic ex = new ExpandoObject();
        ex.TableName = "Products";
        using (var conn = OpenConnection()) { //'conn' is statically typed to 'DBConnection'
            var cmd = CreateCommand(ex); //because 'ex' is dynamic 'cmd' is dynamic
            cmd.Connection = conn; 
            /*
               'cmd.Connection = conn' is bound at runtime and
               the runtime signature of Connection takes a SqlConnection value. 
               You can't assign a statically defined DBConnection to a SqlConnection
               without cast. 
            */
        }
        Console.WriteLine("It will never get here!");
        Console.Read();
        return null;
    }
