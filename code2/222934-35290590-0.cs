     private void printPreviewDialog1_Load(object sender, EventArgs e)
            {
                int j=0;
                z=185;
                while (j < dataGridView1.Rows.Count)
                {
                   
                   
                    j += 1;
    
                    z += 30;
                }
                z += 60;
    
              PaperSize pkCustomSize1 = new PaperSize("First custom size", 350, z);
    
                printDocument1.DefaultPageSettings.PaperSize = pkCustomSize1;
    
                
            }
