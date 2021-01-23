            SaveFileDialog file = new SaveFileDialog();
            DialogResult dialogResult = file.ShowDialog();
            if (dialogResult == DialogResult.OK) {
                if (String.IsNullOrEmpty(file.FileName)) {
                    //Inform the user
                }
                string path = file.FileName;
                FileInfo fi = new FileInfo(path);
                // Open the stream for writing.
                using (FileStream fs = fi.OpenWrite()) {
                    Byte[] info = Encoding.ASCII.GetBytes(richTextBox1.Text);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }
            } else {
                //Inform the user
            }
