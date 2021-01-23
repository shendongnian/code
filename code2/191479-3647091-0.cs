    class Program
    {
        static void Main(string[] args)
        {
            const string filename = @"D:\Temp\dcs_0002.jpg";
            var fileBytes = File.ReadAllBytes(filename);
            var value = BytesAsBinaryString(fileBytes, 50);
            Console.WriteLine(value);
        }
        public static string BytesAsBinaryString(IEnumerable<byte> bytes, int howMany)
        {
            var binaryStrings = from b in bytes 
                          select Convert.ToString(b, 2);
            return String.Join(Environment.NewLine, binaryStrings.Take(howMany));
        }
    }
