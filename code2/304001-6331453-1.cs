    class EncapsulatedReader : TextReader
    {
      private StreamReader _reader;
      public EncapsulatedReader(Stream stream)
      {
        _reader = new StreamReader(stream);      
      }
      public Stream BaseStream
      {
        get
        {
          return _reader.BaseStream;
        }
      }
      public override string ReadLine()
      {
        int c;
        c = Read();
        if (c == -1)
        {
          return null;
        }
        StringBuilder sb = new StringBuilder();
        do
        {
          char ch = (char)c;
          if (ch == ',')
          {
            return sb.ToString();
          }
          else
          {
            sb.Append(ch);
          }
        } while ((c = Read()) != -1);
        return sb.ToString();
      }
      protected override void Dispose(bool disposing)
      {
        if (disposing)
        {
          _reader.Close();
        }
        base.Dispose(disposing);
      }
      public override int Peek()
      {
        return _reader.Peek();
      }
      public override int Read()
      {
        return _reader.Read();
      }
      public override int Read(char[] buffer, int index, int count)
      {
        return _reader.Read(buffer, index, count);
      }
      public override int ReadBlock(char[] buffer, int index, int count)
      {
        return _reader.ReadBlock(buffer, index, count);
      }
      public override string ReadToEnd()
      {
        return _reader.ReadToEnd();
      }
      public override void Close()
      {
        _reader.Close();
        base.Close();
      }
    }
