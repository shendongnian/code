     textBox.Multiline = true; 
     using (WebClient cliente = new WebClient())
     {
          textbox.Text = cliente.DownloadString(url);
     }
