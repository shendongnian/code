                List<User> userList = new List<User>();
    
                // Read the file located at c:\test.txt (this miht be different in your case)
                System.IO.StreamReader file = new System.IO.StreamReader(@"c:\test.txt");
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    //following logic will reach each line and split by the seperator before
                    // creating a new User instance. Remember to add more defensive logic to
                    // cover all cases
                    var extract = line.Split(';');
                   userList.Add(new User()
                   {
                       Id = extract[0],
                       Name = extract[1],
                       IsAdmin = extract[2]
                   });
                }
    
                file.Close();
    
                //at this stage you will have List of User and converting it to array using following call
    
                var userArray = userList.ToArray();
