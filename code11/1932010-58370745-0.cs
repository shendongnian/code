        private void LoadFile_Click(object sender, EventArgs e)
        {
            // dialogs are IDisposable, so use a using block
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return; // deal with if they don't press Ok
                }
                // FileName is already a string you don't need to use .ToString on it
                path = openFileDialog.FileName;
                label1.Text = path;
            }
            var results = File.ReadLines(path)
                .Where(line => string.IsNullOrWhiteSpace(line)==false)
                .ToDictionary(key => key, value => value.Sum(x => x))
                .GroupBy(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Select(y => y.Key).ToList());      
 
            Console.Read();            
        }
