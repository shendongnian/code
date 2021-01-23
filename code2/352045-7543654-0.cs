       try
        {
            using (var sr = File.OpenText("test.txt"))
            {
                bool flag = true;
                string newone = 20110501;//date
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (flag)
                    {
                        MessageBox.Show("Buy : " + line);
                        //Its Displaying more than 50 times i want to displayit only
                        //onetime and should dispose for the next Time
                    }
                    flag = false;
                }
            }
        }
        catch
        {}
