    public static void SplitFil(int rows, string inputFile) {
          int outFileNumber = 1;      
          const int MAX_LINES = 50000;      
          string header = "";
          if (GetFileSize(inputFile) > MAX_LINES) {
            var reader = File.OpenText(inputFile);               
            while (!reader.EndOfStream)
            {
              var start_idx = 0;          
              var writer = File.CreateText($"filename_{outFileNumber}.csv");
              if (outFileNumber > 1) {
                writer.WriteLine(header);
                start_idx = 1;
              }            
              for (int idx = start_idx; idx < MAX_LINES; idx++)
              { 
                var row = reader.ReadLine();
                if (idx == 0 && outFileNumber == 1) header = row;
                writer.WriteLine(row);
                if (reader.EndOfStream) break;
              }
              writer.Close();
              outFileNumber++;
            }
            reader.Close();
          }
        }
