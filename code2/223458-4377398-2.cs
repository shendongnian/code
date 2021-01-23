    string[] files = Directory.GetFiles(textBox1.Text, "*.*", SearchOption.TopDirectoryOnly); 
                
        long h = long.Parse(tbFilePerFolder.Text);
        long i = 0;
        long j = 0;
        long k = files.Count() / h;
        lblFilesFound.Text = "Files Found: " + files.Count();
         while (j <= k + 1)
               {
                    Directory.CreateDirectory(textBox1.Text + @"\" + j.ToString("00000"));
                    lblFoldersCreated.Text = "Folders Created: " + j;
                    j++;
                } 
        
    string[] folders = Directory.GetDirectories(textBox1.Text, "*.*", SearchOption.TopDirectoryOnly) 
            
    //do you really need to search again? or maybe you can just use files instead?
    string[] files2 = Directory.GetFiles(textBox1.Text, "*.*", SearchOption.TopDirectoryOnly); 
                             
                                
                ind d=0;                   
                foreach (string file in files2)
                { 
                   string folder=folders[d];
                   while (i <= h)
                         {
                           File.Move(file, folder + @"\" + Path.GetFileName(file));
                           lblFilesMoved.Text = "Files Moved:" + i;
                           i++; 
                         }
                    d++;
                    i=0;
                 
                }
