      // You can use "using" blocks guarantee streams are disposed (like try/finally { boas.Close(); })
      using (var baos = new MemoryStream())
      {
        // Stream encodes as UTF-8 by default; specify other encodings in this constructor
        using (var ps = new StreamWriter(baos))
        {
          // Format string almost the same, but 'tt' for 'am/pm'
          // Could also use move formatting into
          //    DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt")
          // or ToLongDateString and ToLongTimeString for locale-defined formats
          ps.Write("\n\n+++++ {0} {1:MM/dd/yyyy HH:mm:ss tt}\n", Environment.UserName, DateTime.Now);
          // Need to close or flush the StreamWriter stream before the bytes will
          // appear in the MemoryStream
          ps.Close();
        }
        // Extract bytes from MemoryStream
        var bytes = baos.ToArray();
      }
