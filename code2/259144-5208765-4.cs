    string[] myFile = File.ReadAllLines(@"C:\file.txt");
    var lineCount = myFile.Length;
    
         for(i=0; i<lineCount; i++)  
         {
              switch(i)
              {
                   case 0:
                       //parse line 0
                       break;
                   case 1:
                       //parse line 1
                       break;
                   case 2:
                       //parse line 2
                       break;
                   //and so on until you get to the line that begins the regular "records" part of the file
              }
              if(i >= 10) //assumes line 10 is where the regular "records" start
              {
                  //parse the record like so
                  string[] columns = myFile[i].Split('\t'); //this assumes your columns are separated by a tab. If it's a space you would use myFile[i].Split(' '), etc. 
                  //now you have an array with all your columns
                  foreach(string column in columns)
                  {
                       //now do what you want with the information
                  }
              }
         }
    }
