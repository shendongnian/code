    if (File.Exists(binaryFilePath))
    {
      while (true)
      {
      Program.DisplayMessage("The file: " + binaryFileName + " already exist. Do you want to overwrite it? Y/N");
        string overwrite = Console.ReadLine();
        if (overwrite.toUpper().equals("Y"))
        {
          WriteBinaryFile(frameCodes, binaryFilePath);
          break;
        } 
        else if (overwrite.toUpper().equals("N"))
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
