    static public void save_file(string file_name, string text_to_write)
    {
      using (var stream = File.Exists(file_name) 
        ? new FileStream(file_name, FileMode.Append) 
        : new FileStream(file_name, FileMode.Create))
      {
        using (var writer = new BinaryWriter(stream))
        {
          //writer.Write("hello");
          writer.Write(text_to_write);
          writer.Close();
        }
      }
    }
