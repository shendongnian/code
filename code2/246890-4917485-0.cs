      static void Main(string[] args)
      {
         string inputFile = Path.Combine("C:/temp","textfile.txt");
         string outputFile = Path.Combine("C:/temp","textfile2.txt");
         using(StreamReader input = File.OpenText(inputFile))
         using(Stream output = File.OpenWrite(outputFile))
         using(StreamWriter writer = new StreamWriter(output))
         {
            int count = 1;
            while(!input.EndOfStream)
            {
               // read line 
               string line = input.ReadLine();
               // Get dates 15 days on either side of current date 
               if(count == 13)
               {
                  DateTime beginRange = DateTime.Today.AddDays(-15);
                  DateTime endRange = DateTime.Today.AddDays( 15 );
                  string strBeginDate = beginRange.ToShortDateString();
                  string strEndDate = endRange.ToShortDateString();
                  // replace line with new date range
                  line = "0001" + strBeginDate + strEndDate + "Report submitted by";
               }
               // increment counter
               count++;
               // write the file to temp file 
               writer.WriteLine(line);
            }
         }
         File.Delete(inputFile); // delete original file 
         File.Move(outputFile,inputFile); // rename temp file to original file name 
