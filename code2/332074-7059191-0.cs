    class Processor
    
          private HttpContext _context;
    
          public Processor(HttpContext context) {
               _context = context;
          }
    
          public void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
          {
              Image img = eventArgs.Frame;
              byte[] b = GetImageBytes(eventArgs.Frame);
              HttpContext.Current.Response.OutputStream.Write(b, 0, b.Length);
          }
    }
