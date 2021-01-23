     // Start the Sort.exe process with redirected input.
     // Use the sort command to sort the input text.
     Process myProcess = new Process();
     myProcess.StartInfo.FileName = "Sort.exe";
     myProcess.StartInfo.UseShellExecute = false;
     myProcess.StartInfo.RedirectStandardInput = true;
     myProcess.Start();
     StreamWriter myStreamWriter = myProcess.StandardInput;
     // Prompt the user for input text lines to sort. 
     // Write each line to the StandardInput stream of
     // the sort command.
     String inputText;
     int numLines = 0;
     do 
     {
        Console.WriteLine("Enter a line of text (or press the Enter key to stop):");
        inputText = Console.ReadLine();
        if (inputText.Length > 0)
        {
           numLines ++;
           myStreamWriter.WriteLine(inputText);
        }
     } while (inputText.Length != 0);
