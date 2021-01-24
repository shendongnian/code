    static public class ExtensionMethods
    {
        public static string GetAdditionalVariable<T>(this Grid<T> source)
        {
            return "Hello world";
        }
    }
    var grid = new Grid<int>();
    var s = grid.GetAdditionalVariable();
