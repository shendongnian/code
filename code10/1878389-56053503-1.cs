    if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            if (string.IsNullOrEmpty(openFileDialog1.FileName) {
                // ..
                return; 
            }
            try
            {
    			var fileStream = openFileDialog1.OpenFile();
    
    			using (StreamReader reader = new StreamReader(fileStream))
    			{
    				SetText(sr.ReadToEnd());
    			}		
            }
            catch (SecurityException ex)
            {
                MessageBox.Show($"Security error.\n\nError message{ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
            }
        }
