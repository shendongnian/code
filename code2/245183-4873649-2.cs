    class DynamicConsole : TextWriter
    {
      readonly string filename;
      readonly TextWriter orig;
      readonly TextWriter output;
    
      public DynamicConsole(string filename)
      {
        this.filename = filename;
        orig = Console.Out;
        output = File.AppendText(filename);
        Console.SetOut(output);
      }
    
      public override System.Text.Encoding Encoding
      {
        get { return output.Encoding; }
      }
    
      public override void Write(char value)
      {
        output.Write(value);
      }
    
      protected override void Dispose(bool disposing)
      {
        Console.SetOut(orig);
        output.Dispose();
      }
    }
