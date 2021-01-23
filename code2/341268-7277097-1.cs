     using (StreamReader sr = new StreamReader("TestFile.txt")) 
        {
           String line;
           while ((line = sr.ReadLine()) != null) 
              {
                // string data = line.subString(0,3000); 
                // edit, if data is sometimes < 3000 ....  
                string data = line.subString(0,line.length < 3000 ? line.length : 3000);
                // do something with data
              }
         }
