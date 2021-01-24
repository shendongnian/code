public static void Optimize(string filePath, string outputPath, string fileName, string fileNum)
            {
                PDFNet.Initialize();
                try
                {
                        using (PDFDoc doc = new PDFDoc(filePath)) 
                        {
                            //--------------------------------------------------------------------------------
                            // Example 1) Simple optimization of a pdf with default settings.
                            doc.InitSecurityHandler();
                            Optimizer.Optimize(doc);
                            Directory.CreateDirectory(outputPath + filePath.Substring(41, 7));
                            doc.Save(filePath, SDFDoc.SaveOptions.e_linearized);
                            //doc.Save(outputPath + fileNum + fileName, SDFDoc.SaveOptions.e_linearized);
                            Console.WriteLine("Done..\n");
                        }
                }
                catch (PDFNetException e)
                {
                        Console.WriteLine(e.Message);
                }
            }
            public static void Run()
            {
                // Create a new FileSystemWatcher and set its properties.
                // Params: Path, and filter
                using (FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\user\Desktop\testinpactive", "*.pdf"))
                {
                    // To watch SubDirectories 
                    watcher.IncludeSubdirectories = true;
                    FswHandler Handler = new FswHandler();
                    // Add event handlers.
                    watcher.Created += Handler.OnCreated;
                    // Begin watching.
                    watcher.EnableRaisingEvents = true;
                    // Wait for the user to quit the program.
                    Console.WriteLine("Press 'q' to quit the sample.");
                    while (Console.Read() != 'q');
                }
            }
            public class FswHandler
            {
                public void OnCreated(Object source, FileSystemEventArgs e)
                {
                    string output = @"C:\Users\user\Desktop\output";
                    // Write out Path (Testing)
                    Console.WriteLine($"FILE: {e.FullPath} CHANGE-TYPE: {e.ChangeType}");
                    Thread.Sleep(800);
                    // Specify what is done when a file is changed, created, or deleted.
                    Optimize(e.FullPath, output, e.Name.Substring(7), e.FullPath.Substring(40, 8));
                }
            }
