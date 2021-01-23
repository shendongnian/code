    public class Foo
    {
        public static void Main()
        {
            var myPage = "test string";
            var repo =  new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(myPage));
        }
    }
    
