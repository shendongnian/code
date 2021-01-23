    static public class ITableBaseExtensions{
        static public string GetIdAsString(this ITableBase table){
            return table.Id.ToString();
        }
        static public int UsingMethod2(this ITableBase table){
            var i = table.Method2();
            return i * 5 + 9 - 14 / 3 % 7 /* etc... */;
        }
        static public void AddingNewMethodToTables(this ITableBase table, string some_string,
            int some_int, YourType any_other_parameter /* etc... */ ){
            // implement the method you want add to all Table classes
        }
        // 
        // You can add any method you want to add to table classes, here, as an Extension method
        //
    }
