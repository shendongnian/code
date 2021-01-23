    using (var input = new StreamReader(File.OpenRead(inputFileName), Encoding.ASCII))
    {
      string line;
      while((line = input.ReadLine()) != null) // or read data other way you want
      {
        //Do something here...
      }
    }
