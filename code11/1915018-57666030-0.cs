    namespace Solution
    {
        class Solution
        {
            static void Main(string[] args)
            {
                var reader = new ChunkReader();
                Chunk chunk = null;
    
                foreach (Chunk c in reader.Read(@"D:\test.txt"))
                {
                    Console.WriteLine(c.Header);
                }
    
                Console.ReadKey();
            }
        }
    
        internal class ChunkReader
        {
            public IEnumerable<Chunk> Read(string filePath)
            {
                Chunk currentChunk = null;
    
                using (StreamReader reader = new StreamReader(File.OpenRead(filePath)))
                {
                    string currentLine;
    
                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        if (currentLine.StartsWith("01"))
                        {
                            if (currentChunk != null)
                            {
                                yield return currentChunk;
                            }
    
                            currentChunk = new Chunk();
                            currentChunk.Contents.Add(currentLine);
                        }
                        else
                        {
                            currentChunk?.Contents.Add(currentLine);
                        }
                    }
                }
    
                yield return currentChunk;
            }
        }
        
        internal class Chunk
        {
            public Chunk()
            {
                Contents = new SortedSet<string>();
            }
    
            public SortedSet<string> Contents { get; }
    
            public string Header
            {
                get
                {
                    return Contents.FirstOrDefault(s => s.StartsWith("01"));
                }
            }
        }
    }
