C# 
             
                if (File.Exists(FileToDecrypt)) {
                    byte[] PasswordBytes;
                    if (IsFileTypePassword) {
                        PasswordBytes = File.ReadAllBytes(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),"K3ys\\" + PasswordToDecrypt));
                    } else {
                        PasswordBytes = Encoding.UTF8.GetBytes(PasswordToDecrypt);
                    }
                    DecryptFile(5000000, FileToDecrypt, PasswordBytes); // Here was the problem
                    DecThread.Abort();
                }
            
And here is the function that splits the file, its a little bit different than mine but it does the same, also this piece of code is grabbed from another Question form StackOverflow.
C#
public static void SplitFile(string inputFile, int chunkSize, string path)
{
    byte[] buffer = new byte[chunkSize];
    using (Stream input = File.OpenRead(inputFile))
    {
        int index = 0;
        while (input.Position < input.Length)
        {
            using (Stream output = File.Create(path + "\\" + index))
            {
                int chunkBytesRead = 0;
                while (chunkBytesRead < chunkSize)
                {
                    int bytesRead = input.Read(buffer, 
                                               chunkBytesRead, 
                                               chunkSize - chunkBytesRead);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    chunkBytesRead += bytesRead;
                }
                output.Write(buffer, 0, chunkBytesRead);
            }
            index++;
        }
    }
}
