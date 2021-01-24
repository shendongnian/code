        private void Form1_Load(object sender, EventArgs e)
        {
            String con_env = textName.Text.ToString();
            UserDetails ud = SearchFor(con_env);
            //if ud is null then do not set values to text box
            if(ud != null)
            {
               textSurname.Text = ud.surname;
               textCity.Text = ud.city;
               textState.Text = ud.state; 
            }
           else  //else block to set default value
           {
              textSurname.Text = "Default value";
               textCity.Text = "Default value";
               textState.Text = "Default value"; 
 
            }   
        }
        UserDetails SearchFor(String searchName)
        {
            var strLines = File.ReadLines(filePath);
            foreach (var line in strLines)
            {
                var bits = line.Split(',');
                if (bits[0].Equals(searchName))
                {
                    return new UserDetails()
                    {           
                        surname = bits[1],
                        city = bits[2],
                        state = bits[3],                     
                    };
                }
            }
            return null;
        }
