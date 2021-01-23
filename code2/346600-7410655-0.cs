            byte[] buffer = File.ReadAllBytes(currentFile);
            if (currentEncoding == encoding.utf8)
            {
                buffer = System.Text.Encoding.UTF8.GetBytes(mainTxtBx.Text);
            }
            else
            {
                buffer = System.Text.Encoding.ASCII.GetBytes(mainTxtBx.Text);
            }
            File.WriteAllBytes(currentFile, buffer);
