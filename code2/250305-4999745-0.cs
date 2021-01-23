            System.Windows.Forms.OpenFileDialog FD = new System.Windows.Forms.OpenFileDialog();
            if (FD.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                string fileToOpen = FD.FileName;
                
                System.IO.FileInfo File = new System.IO.FileInfo(FD.FileName);
                //OR
                System.IO.StreamReader reader = new System.IO.StreamReader(fileToOpen);
                //etc
            }
