    foreach (var pdfFile in resultFilesPDF)
            {
                foreach (var wordFile in resultFiles)
                {
                    if (wordFile == pdfFile)
                    {
                        //Get Filename                    
                        var filename = System.IO.Path.GetFileName(wordFile + ".docx");
                        //Move Files
                        File.Move(wordFile + ".docx", @"c:\test2\" + "\\" + filename);
                    }
                }
            }
