    public class LineBreakNormaliser : TextReader
    {
      private readonly TextReader _source;
      private bool isNewLine(int charAsInt)
      {
        switch(charAsInt)
        {
          case '\n': case '\r':
          case '\u0085': case '\u2028': case '\u2029':
          case '\u000B': case '\u000C':
            return true;
          default:
            return false;
        }
      }
      public LineBreakNormaliser(TextReader source)
      {
        _source = source;
      }
      public override void Close()
      {
        _source.Close();
        base.Close();
      }
      protected override void Dispose(bool disposing)
      {
        if(disposing)
          _source.Dispose();
        base.Dispose(disposing);
      }
      public override int Peek()
      {
        int i = _source.Peek();
        if(i == -1)
          return -1;
        if(isNewLine(i))
          return '\n';
        return i;
      }
      public override int Read()
      {
        int i = _source.Read();
        if(i == -1)
          return -1;
        if(i == '\r')
        {
          if(_source.Peek() == '\n')
            _source.Read(); //eat next half of CRLF pair.
          return i;
        }
        if(isNewLine(i))
          return '\n';
        return i;
      }
      public override int Read(char[] buffer, int index, int count)
      {
        //We take advantage of the fact that we are allowed to return fewer than requested.
        //ReadBlock does the work for us for those who need the full amount:
        char[] tmpBuffer = new char[count];
        int cChars = count = _source.Read(tmpBuffer, 0, count);
        if(cChars == 0)
          return 0;
        for(int i = 0; i != cChars; ++i)
        {
          char cur = tmpBuffer[i];
          if(cur == '\r')
          {
            if(i == cChars -1)
            {
              if(_source.Peek() == '\n')
              {
                _source.Read(); //eat second half of CRLF
                --count;
              }
            }
            else if(tmpBuffer[i + 1] == '\r')
            {
              ++i;
              --count;
            }
            buffer[index++] = '\n';
          }
          else if(isNewLine(cur))
            buffer[index++] = '\n';
          else
            buffer[index++] = '\n';
        }
        return count;
      }
    }
