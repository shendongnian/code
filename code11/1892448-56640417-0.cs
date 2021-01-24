    internal class Program
      {
        private static void Main()
        {
            var inputText = Console.ReadLine();
            var huffman = new Huffman<char>(inputText);
            List<int> encoding = huffman.Encode(inputText);
            List<char> decoding = huffman.Decode(encoding);
            var outString = new string(decoding.ToArray());
            Console.WriteLine(outString == inputText ? "Encoding/decoding 
        worked" : "Encoding/Decoding failed");
    
            var chars = new HashSet<char>(inputText);
            foreach (char c in chars)
            {
                encoding = huffman.Encode(c);
                Console.Write("{0}: ", c);
                foreach(int bit in encoding)
                {
                    Console.Write("{0}", bit);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
