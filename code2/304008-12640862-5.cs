    class Program
    {
        static long _fileposition = 0;
        static void Main(string[] args)
        {
            // Check information passed in
            if (args.Any())
            {
                if (args[0] == "/?")
                {
                    var message = "Splits a file into smaller pieces";
                    message += "\n";
                    message += "\n";
                    message += "SplitFile [sourceFileName] [destinationFileName] [RowBatchAmount] [FirstRowHasHeader]";
                    message += "\n";
                    message += "\n";
                    message += "     [sourceFileName]  (STRING) required";
                    message += "\n";
                    message += "     [destinationFileName]  (STRING) will default to the same location as the sourceFileName";
                    message += "\n";
                    message += "     [RowBatchAmount]   (INT) will create files that have this many rows";
                    message += "\n";
                    message += "     [FirstRowHasHeader]    (True/False) Will Add Header Row to each new file";
                    Console.WriteLine(message);
                }
                else
                {
                    string sourceFileName = args[0];
                    string destFileLocation = args.Count() == 2 ? args[1] : sourceFileName.Substring(0, sourceFileName.LastIndexOf("\\"));
                    int RowCount = args.Count() == 3 ? int.Parse(args[2]) : 50000;
                    bool FirstRowHasHeader = true;
                    FirstRowHasHeader = args.Count() != 4 || bool.Parse(args[3]);
                    // Create Directory If Needed
                    if (!Directory.Exists(destFileLocation))
                    {
                        Directory.CreateDirectory(destFileLocation);
                    }
                    string line = "";
                    int linecount = 0;
                    int FileNum = 1;
                    string newFileName = Path.Combine(destFileLocation, Path.GetFileNameWithoutExtension(sourceFileName));
                    newFileName += FileNum + Path.GetExtension(sourceFileName);
                    // Always add Header Line
                    string HeaderLine = GetLine(sourceFileName, _fileposition);
                    int HeaderCount = HeaderLine.Split('|').Count();
                    do
                    {
                        // Add Header Line
                        if ((linecount == 0 & FirstRowHasHeader) | (_fileposition == 1 & !FirstRowHasHeader))
                        {
                            using (FileStream NewFile = new FileStream(newFileName, FileMode.Append))
                            {
                                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                                Byte[] bytes = encoding.GetBytes(HeaderLine);
                                int length = encoding.GetByteCount(HeaderLine);
                                NewFile.Write(bytes, 0, length);
                            }
                        }
                        // Get New Line
                        line = GetLine(sourceFileName, _fileposition, HeaderCount);
                        
                        // Create File if it doesn't exist and write to it
                        using (FileStream NewFile = new FileStream(newFileName, FileMode.Append))
                        {
                            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                            Byte[] bytes = encoding.GetBytes(line);
                            int length = encoding.GetByteCount(line);
                            NewFile.Write(bytes, 0, length);
                        }
                        
                        //Add to the line count
                        linecount++;
                        //Create new FileName if needed
                        if (linecount == RowCount)
                        {
                            FileNum++;
                            // Create a new sub File, and read into it
                            newFileName = Path.Combine(destFileLocation, Path.GetFileNameWithoutExtension(sourceFileName));
                            newFileName += FileNum + Path.GetExtension(sourceFileName);
                            linecount = 0;
                        }
                    } while (line.Any());
                }
            }
            else
            {
                Console.WriteLine("You must provide sourcefile!");
                Console.WriteLine("use /? for help");
            }
        }
        static string GetLine(string sourceFileName, long position, int NumberOfColumns = 0)
        {
            byte[] buffer = new byte[65536];
            var builder = new StringBuilder();
            var finishedline = false;
            using (Stream source = File.OpenRead(sourceFileName))
            {
                source.Position = position;
                var crlf = "\r\n";
                var lf = "\n";
                while (source.Position < source.Length)
                {
                    using (TextReader NewLine = new StreamReader(source))
                    {
                        while (NewLine.Peek() >= 0 & finishedline == false)
                        {
                            var c = (char)NewLine.Read();
                            var clmnCount = builder.ToString().Split('|').Count();
                            _fileposition++;
                            switch (c)
                            {
                                case '\r':
                                    {
                                        builder.Append(c);
                                        
                                        var next = NewLine.Peek();
                                        if (next == '\n')
                                        {
                                            if ((clmnCount == NumberOfColumns) | NumberOfColumns == 0)
                                            {
                                                // Remove all Control Line Feeds before the end of the line.
                                                builder = builder.Replace(crlf, lf);
                                                // Add Final Control Line Feed
                                                var x = (char)NewLine.Read();
                                                builder.Append(x);
                                                finishedline = true;
                                                _fileposition++;
                                                continue;
                                            }
                                        }
                                        break;
                                    }
                                default:
                                    builder.Append(c);
                                    break;
                            }
                        }
                    }
                    break;
                }
            }
            return builder.ToString();
        }
    }
