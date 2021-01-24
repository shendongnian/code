    using SharpCompress.Compressors.BZip2;
    using System;
    using System.IO;
    using System.Text;
    
    class Program
    {
        static void Main(string[] args)
        {
            string base64;
            using (var reader = File.OpenText(args[0]))
            {
                // Skip the first line, which has some header information
                // TODO: Use it instead, to validate the rest of the data.
                reader.ReadLine();
                base64 = reader.ReadToEnd();
            }
    
            byte[] bytes = Convert.FromBase64String(base64);
    
            int startOfBody = FindStartOfBody(bytes);
            using (var input = new MemoryStream(bytes, startOfBody, bytes.Length - startOfBody))
            {
                using (var bzip2 = new BZip2Stream(input, SharpCompress.Compressors.CompressionMode.Decompress, true))
                {
                    using (var output = File.OpenWrite(args[1]))
                    {
                        bzip2.CopyTo(output);
                    }
                }
            }
        }
    
        private static int FindStartOfBody(byte[] bytes)
        {
            // The file starts with a "header" of an unknown format, which we need to
            // skip. It looks like the format *might* be a sequence of comma-separated values
            // - Name of some kind (BZIP2)
            // - Number of further values
            // - The remaining values
            // That's what this code does.
            int offset = 0;
            // Skip the name
            GetNextHeaderValue(bytes, ref offset);
            // Find out how many more values there are
            string valueCountText = GetNextHeaderValue(bytes, ref offset);
            int valueCount = int.Parse(valueCountText);
            // Skip them
            for (int i = 0; i < valueCount; i++)
            {
                GetNextHeaderValue(bytes, ref offset);
            }
            // We'll now be positioned at the end
            return offset;
        }
    
        private static string GetNextHeaderValue(byte[] bytes, ref int offset)
        {
            StringBuilder builder = new StringBuilder();
            // TODO: Validation that we're not going past the end of the data...
            // We assume all header data is ASCII.
            for (; bytes[offset] != ','; offset++)
            {
                builder.Append((char) bytes[offset]);
            }
            // Move the offset past the comma
            offset++;
            return builder.ToString();
        }
    }
