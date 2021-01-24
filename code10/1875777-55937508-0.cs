               int i = 0;
               //no need use close method with using
                using (StreamReader sr = new StreamReader(File.Open("C:\\Users\\user\\Documents\\Projects\\AdministratorModule//userTextFile.txt", FileMode.Open))) 
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        
                        if(i == 0)
                        {
                            user1 = line;
                        }
                        else if (i == 1)
                        {
                            password1 = line;
                        }
    
                        //rest of your logic
                       i++;               
                 }
                
