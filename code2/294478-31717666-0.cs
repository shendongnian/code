       private void WORKING_HELP()
        {
            string filePath = Directory.GetCurrentDirectory() + "\\BlitzHelp.chm";
           
            try
            {
                //Check if already exists before making
                if (!File.Exists(filePath))
                {
                    var data = Properties.Resources.BlitzHelp;
                    using (var stream = new FileStream("BlitzHelp.chm", FileMode.Create))
                    {
                        stream.Write(data, 0, data.Count());
                        stream.Flush();
                    }
                    MessageBox.Show("file made");
                }
            }
            catch
            {
                //May already be opened
            }
            Help.ShowHelp(this, filePath);
        }
