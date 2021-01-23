    while((line = file.ReadLine()) != null)
        {
            if (line.StartsWith("#")) continue; //Line is a commment so skip
            else
            {
               string[] data = line.Split(':');
              if(data.Length>0)
              {
                if(this.Controls.ContainsKey(data[0]))
                {
                  if(this.Controls[data[0]] is TextBox)
                 {
                   //generic 
                 // this.Controls[data[0]].Text=data[1];
                    //or use
                    ((TextBox) this.Controls[data[0]]).Text=data[1];
                 }
                }
              }
            }
        }
