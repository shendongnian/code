     using (StreamWriter sw = File.AppendText(@"c:\output.txt"))
     {
          using(StreamReader sr = new StreamReader(@"input.txt"))
          {                    
            
              string myString = "";
              while (!sr.EndOfStream)
              {
                     
                    myString = sr.ReadLine();
                    int index = myString.LastIndexOf(":");
                    if (index > 0)
                        myString = myString.Substring(0, index);
         
                    sw.WriteLine(myString);
               }
           }
      }
