    public void WriteTo4() {
      var PathFileName = directoryInfo.FullName + @"\Test1.csv";
      using (var fileStream = new FileStream(PathFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None, bufferSize, FileOptions.SequentialScan)) {
        using (var streamWriter = new StreamWriter(fileStream)) {
          var lineBuffer = new char[100];
          Span<char> span = lineBuffer;
          for (int i = 0; i < iterations; i++) {
            var ok = i.TryFormat(span, out var charsWritten);
            lineBuffer[charsWritten++] = ';';
            var span1 = span[charsWritten..];
            ok = (i+1).TryFormat(span1, out charsWritten);
            span1[charsWritten++] = ';';
            span1 = span1[charsWritten..];
            ok = (i+2).TryFormat(span1, out charsWritten);
            span1[charsWritten++] = ';';
            span1 = span1[charsWritten..];
            ok = (i+3).TryFormat(span1, out charsWritten);
            span1[charsWritten++] = ';';
            span1 = span1[charsWritten..];
            ok = (i+4).TryFormat(span1, out charsWritten);
            span1[charsWritten++] = ';';
            span1 = span1[charsWritten..];
            ok = (i+5).TryFormat(span1, out charsWritten);
            span1[charsWritten++] = ';';
            span1 = span1[charsWritten..];
            ok = (i+6).TryFormat(span1, out charsWritten);
            span1[charsWritten++] = ';';
            var ca = lineBuffer[..(lineBuffer.Length - span1.Length + charsWritten)];
            streamWriter.WriteLine(lineBuffer, 0, lineBuffer.Length - span1.Length + charsWritten);
          }
        }
      }
    }
