    if (e.Data.GetDataPresent(DataFormats.FileDrop))
    {
          string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
          foreach (string filePath in files) 
          {
              Console.WriteLine(filePath );
          }
    }
