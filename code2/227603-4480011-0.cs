    class FileLogger {
      private TimeSpan timeout;
      private DateTime openedFile;
      private Stream output;
      private StreamWriter writer;
      public Dispose() {
        if (writer != null) {
          writer.Dispose();
          writer = null;
        };
        if (output != null) {
          output.Dispose();
          output = null;
        }
      }
      public void Log(string message) {
        if (output == null
            || ((DateTime.UtcNow - openedFile) > timeout) {
          Dispose();
          string filename = MakeFileName();
          output = new FileStream(filename, FileMode.Append, FileAccess.Write, FileShare.Read);
          writer = new StreamWriter(output);
          openedFile = DateTime.UtcNow;
        }
        writer.WriteLine(writer);
      }
    }
