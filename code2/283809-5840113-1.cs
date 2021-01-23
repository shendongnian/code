           s.ReadTimeout = 1000;
           try
           {
              sw.WriteLine(sendMsg);
              
              while(true)
              {
                r = sr.ReadLine();
                Console.WriteLine(r);
              } 
             sr.DiscardBufferedData(); 
           }
          catch(IOException)
           {
             //Timed out—probably no more to read
           }
