    //the ReadBowlers method reads the names of bowlers 
        //into the listBowlers.
        private void ReadBowlers(List<Bowler> listBowlers)
        {
            try
            {
                //Open the Bowlers.txt file.
                string path = @"Bowlers.txt";
                //read the names into the list
                
                using (FileStream fs = File.OpenRead(path))
                {
                    byte[] b = new byte[1024];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (fs.Read(b,0,b.Length) > 0)
                    {
                        listBowlers.Add(temp.GetString(b));
                    }
                }
                
            }
            catch (Exception ex)
            {
                //display error message
                MessageBox.Show(ex.Message);
            }
        }
