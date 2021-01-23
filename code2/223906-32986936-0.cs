        private static void ConvertAnsiToUTF8(string inputFilePath, string outputFilePath)
        {
            string fileContent = File.ReadAllText(inputFilePath, Encoding.Default);
            File.WriteAllText(outputFilePath, fileContent, Encoding.UTF8);
        }
