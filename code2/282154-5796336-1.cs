    string[] filesNames = new[] { "file_1.dat", "file_2.dat", "file_3.dat" };
    foreach (var name in filesNames)
    {  
        // ... 
        if (binaryExists)
        {
            bool isFileProcessed = false;
            Program.DisplayUserOptionMessage("The file: " + binaryFileName 
                + " exist. You want to overwrite it? Y/N");
            while (!isFileProcessed)
            {
                string overwrite = Console.ReadLine();
                if (overwrite.ToUpper() == "Y")
                {
                    WriteBinaryFile(frameCodes, binaryFilePath);
                    isFileProcessed = true; 
                }
                else if (overwrite.ToUpper() == "N")
                {
                    isFileProcessed = true; 
                } 
                else
                {
                    // here we do nothing with isFileProcessed flag: 
                    // user still needs to select proper option, loop continues 
                    Program.DisplayUserOptionMessage(
                        "!!Please Select a Valid Option!!");
                }
            } 
         }
     }
