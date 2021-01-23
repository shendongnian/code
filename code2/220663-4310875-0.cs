     public void Split(string inputfile, string outputfilesformat) {
         int i = 0;
         System.IO.StreamWriter outfile = null;
         string line; 
         try {
              using(var infile = new System.IO.StreamReader(inputfile)) {
                   while(!infile.EndOfStream){
                       line = infile.ReadLine();
                       if(string.IsNullOrEmpty(line)) {
                           if(outfile != null) {
                               outfile.Dispose();
                               outfile = null;
                           }
                           continue;
                       }
                       if(outfile == null) {
                           outfile = new System.IO.StreamWriter(string.Format(outputfilesformat, i++), false, infile.CurrentEncoding);
                       }
                       outfile.WriteLine(line);
                   }
              }
         } finally {
              if(outfile != null)
                   outfile.Dispose();
         }
     }
