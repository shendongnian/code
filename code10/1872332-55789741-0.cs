public class ClassFactory
    {
        public static Action GetTable(string classObj)
        {
            switch (classObj)
            {
                case "Scroll": return "Book_table";
                case "Book": return "Book_table";
            }
        }
     }
