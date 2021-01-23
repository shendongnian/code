     class MainForm
     {
         private string fullPath1;
         
         void Picture()
         {
            if (DataBaseSelection.SelectedIndex+1==1) 
            {
               Logo1_pictureBox.Image=new Bitmap(@"Logos\\aa.bmp");
               var file1 = Path.ChangeExtension(Printer2_TextBox.Text, ".jpg");
               fullPath1 = Path.Combine(@"Documents\\Base\\", file1);
               if (!File.Exists(fullPath1))
               {
                  MessageBox.Show("No picture!");
               }
               else
               {
                  Logo_pictureBox.Image = new Bitmap(fullPath1);
               }
            }
          }
         void ZoomPictureBoxClick(object sender, EventArgs e)
         {
             ZoomSchematic settings = new ZoomSchematic(this.fullPath1);
             settings.ShowDialog();          
         }
     }
     class ZoomSchematic
     {   
         string _fullPath1;
         public ZoomSchematic(string fullPath1)
         {
            _fullPath1 = fullPath1;
         }
     }
