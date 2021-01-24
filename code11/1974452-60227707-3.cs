namespace Opgavens_leerpad_3_oefening
{
    class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Can the cat find the mouse without waking the dog.");
            sb = replacethisstring(sb);
            Console.WriteLine(sb.ToString());
            Console.ReadLine(); // To Stop the Console from closing.
            static StringBuilder replacethisstring(StringBuilder dogCat)
            {
                dogCat = dogCat.Replace("cat", "littlecat");
                dogCat = dogCat.Replace("dog", "littldog");
                dogCat = dogCat.Replace("mouse", "littlemouse");
                dogCat = dogCat.Replace("the", "a");
                return dogCat;
            }
        }
    }
}
You can place the function within the Main or outside. Normally you would find functions outside of the Main class.
    public static void Main(string[] args)
    {
    ...
    }
    
    public static string replacethisstring(string dogCat)
    {
    ...
    }
