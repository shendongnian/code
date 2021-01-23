    class Program
        {
            static void Main(string[] args)
            {
                FileBase fb = new FileBase();
                Console.WriteLine(fb.GetMonth());
    
                FooFile ff = new FooFile();
                Console.WriteLine(ff.GetMonth());
    
                Console.ReadLine();
    
            }
        }
    
       public class FileBase
       {
           public string GetMonth()
           {
               return "FileBase::GetMonth()";
           }
    
        }
    
        public class FooFile : FileBase
        {
            public new string GetMonth() // Hides the base method
           {
               return "FooFile::GetMonth()";
           }
        }
