namespace Opgavens_leerpad_3_oefening
{
    class Program
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            string dogCat = new string("Can the cat find the mouse without waking the dog.");
            string response = replacethisstring(dogCat);
            //response will be string with replaced text.
            static string replacethisstring(string dogCat)
            {
                
                string hondKat = dogCat.Replace("cat", "littlecat");
                hondKat = dogCat.Replace("dog", "littldog");
                hondKat = dogCat.Replace("mouse", "littlemouse");
                hondKat = dogCat.Replace("the", "a");
                return hondKat;
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
