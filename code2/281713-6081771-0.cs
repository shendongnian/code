    static void Main(string[] args)
            {
                //...
    
                if (File.Exists(binaryFilePath))
                {
                    if(ReadBool("The file: " + binaryFileName + " exist. You want to overwrite it? Y/N"))
                        WriteBinaryFile(frameCodes, binaryFilePath);
                    else
                        throw new IOException();
                }
            }
    
    static bool ReadBool(String question)
            {
                while (true)
                {
                    Console.WriteLine(question);
                    String r = (Console.ReadLine() ?? "").ToLower();
                    if (r == "y")
                        return true;
                    if (r == "n")
                        return false;
                    Console.WriteLine("!!Please Select a Valid Option!!");
                }
            }
