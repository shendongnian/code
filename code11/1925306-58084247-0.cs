C#
    public class GameInfo
    {
        public string Title
        {
            get;
            set;
        }
        public string Genre
        {
            get;
            set;
        }
        public string Plat
        {
            get;
            set;
        }
    }
2. To answer your questions i rewrote your functions quickly (if i understood you question correctly your code didn't work):
Saving the information:
private void BtngameSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.FileName = "mygames.dat";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                    {
                        using (StreamWriter writer = new StreamWriter(fs))
                        {
                            for(int i = 0; i < ptr; ++i)
                            {
                                writer.WriteLine(gameQueueTitle[i] + "*" + gameQueueGenre[i] + "*" + gameQueuePlat[i]);
                            }
                        }
                        fs.Close();
                    }
                    
                    MessageBox.Show("File saved");
                }
                catch
                {
                    MessageBox.Show("Couldn't save the binary file");
                }
            }
        }
Opening the saved file:
        private void BtngameOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog() == DialogResult.OK)
            { 
                try
                {
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                    {
                        using (StreamReader reader = new StreamReader(fs))
                        {
                            ptr = 0;
                            for (ptr = 0; !reader.EndOfStream; ++ptr)
                            {
                                string line = reader.ReadLine();
                                string[] values = line.Split('*');
                                gameQueueTitle[ptr] = values[0];
                                gameQueueGenre[ptr] = values[1];
                                gameQueuePlat[ptr] = values[2];
                            }
                        }
                        fs.Close();
                    }
                    MessageBox.Show("File processed");
                }
                catch
                {
                    MessageBox.Show("Couldn't open the binary file");
                }
            }
        }
3. Only save or open a file if the Dialog Result is Ok. Your code saves/read the file even if the user cancels the dialog. No user expects this behavior.
