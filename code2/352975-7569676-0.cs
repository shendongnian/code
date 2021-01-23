    public class MapReader
    {
        private string fileName;
    
        private MapReader(Func<string> fileName)
        {
            this.fileName = fileName();
        }
    
        public MapReader(string fileName) : this(() => fileName)
        {
        }
    
        public MapReader() : this(() => 
            {
                Console.WriteLine("Input valid file name:");
                Console.ReadLine();
            })
        {
        }
    }
