    public class ClassFactory
        {
            public static Action GetTableName(string className)
            {
                switch (className)
                {
                    case "Scroll": return "Book_table";
                    case "Book": return "Book_table";
                }
            }
         }
