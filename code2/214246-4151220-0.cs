    #using system.io        
            
    private void RecurseFiles()
            {
                String[] files = Directory.GetFiles(@"c:\dev\", "*.tif", SearchOption.AllDirectories);
    
                int c = 1;
                for (int i = 0; i < files.Length; i++)
                {
                    for (int j = c; j < files.Length; j++)
                        CompareFiles(files[i], files[j]);
                    c++;
                }
            }
    
