    using System.IO;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            // This is the sequence of characters
            var invalid = Path.GetInvalidFileNameChars().Concat(new[] { '&' });
            // If you want them as an array you can do this
            var invalid2 = invalid.ToArray();
            // If you want them as a string you can do this
            var invalid3 = new string(invalid.ToArray());
        }
    }
