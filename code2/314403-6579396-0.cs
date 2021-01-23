     struct OutputFormat
     {
          public int Id { get; private set; }
          public OutputFormats Format { get; private set; }
          public string Filename { get; private set; }
          public OutputFormat(int id, OutputFormats format, string filename)
          {
              Id = id;
              Format = format; 
              Filename = filename;
          }
     }
