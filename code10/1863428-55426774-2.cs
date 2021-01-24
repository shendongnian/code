    public class FileWriterHelper : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // Compare null
            if (x == null) return y == null ? 0 : 1;
            if (y == null) return -1;
            // Compare count of parts split on '.'
            var xParts = x.Split('.');
            var yParts = y.Split('.');
            if (xParts.Length < 3) return yParts.Length < 3 ? 0 : -1;
            if (yParts.Length < 3) return 1;
            // Compare numeric portion
            int xNum, yNum;
            if (int.TryParse(xParts[1], out xNum) &&
                int.TryParse(yParts[1], out yNum))
            {
                return xNum.CompareTo(yNum);
            }
            // Unknown values
            return string.Compare(x, y, StringComparison.Ordinal);
        }
        private static int? GetFileNumber(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName)) return null;
            var fileParts = fileName.Split('.');
            int fileNum;
            if (fileParts.Length < 3 || !int.TryParse(fileParts[1], out fileNum)) return null;
            return fileNum;
        }
        private static string IncrementNumber(string fileName)
        {
            var number = GetFileNumber(fileName).GetValueOrDefault() + 1;
            var fileParts = fileName.Split('.');
            return $"{fileParts[0]}.{number}.{fileParts[fileParts.Length - 1]}";
        }
        private static string GetLatestFile(string filePath, int maxLines)
        {
            var fileDir = Path.GetDirectoryName(filePath);
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            var fileExt = Path.GetExtension(filePath);
            var latest = Directory.GetFiles(fileDir, $"{fileName}*{fileExt}")
                .OrderByDescending(f => f, new FileWriterHelper())
                .FirstOrDefault() ?? filePath;
            return File.Exists(latest) && File.ReadAllLines(latest).Length >= maxLines
                ? Path.Combine(fileDir, IncrementNumber(Path.GetFileName(latest)))
                : latest;
        }
        public static void WriteLinesToFile(string filePath, string header, 
            List<string> lines, int maxFileLines)
        {
            while ((lines?.Count ?? 0) > 0 && maxFileLines > 0)
            {
                var latestFile = GetLatestFile(filePath, maxFileLines);
                if (!File.Exists(latestFile)) File.CreateText(latestFile).Close();
                var lineCount = File.ReadAllLines(latestFile).Length;
                if (lineCount == 0 && header != null)
                {
                    File.WriteAllText(latestFile, string.Concat(header, Environment.NewLine));
                    lineCount = 1;
                }
                var numLinesToWrite = maxFileLines - lineCount;
                File.AppendAllLines(latestFile, lines.Take(numLinesToWrite));
                lines = lines.Skip(numLinesToWrite).ToList();
            }
        }
    }
