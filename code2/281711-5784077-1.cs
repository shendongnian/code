    if (File.Exists(binaryFilePath))
    {
      while (true)
      {
      Program.DisplayMessage("The file: " + binaryFileName + " already exist. Do you want to overwrite it? Y/N");
        string overwrite = Console.ReadLine();
        if (overwrite.ToUpper().Equals("Y"))
        {
          WriteBinaryFile(frameCodes, binaryFilePath);
          break;
        } 
        else if (overwrite.ToUpper().Equals("N"))
        {
          Console.WriteLine("Aborted by user.")
          break;
        } 
        else
        {
          Program.DisplayMessage("!!Please Select a Valid Option!!");
          overwrite = Console.ReadLine();
          continue; // not needed - for educational use only ;)
        }
      }
    }
