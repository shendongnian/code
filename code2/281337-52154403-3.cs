        private void ResumeCopyTo(string sourceFilePath, string destFilePath)
        {
            FileStream input = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);
            FileStream output = new FileStream(destFilePath, FileMode.Append, FileAccess.Write);
            ResumeCopy(input, output);
            output.Close();
            input.Close();
        }
