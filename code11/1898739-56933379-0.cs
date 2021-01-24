     int nTotalNumber = 0;
     int nCurrentItem = 0;
     List<string> ImageFilenames = new List<string>();
     private void LoadImage()
     {
       using (OpenFileDialog open = new OpenFileDialog())
       {
          open.Multiselect = true;
          open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp;*.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
          if (open.ShowDialog() == DialogResult.OK)
          {
             string sFileName = open.FileName;
             ImageFilenames = open.FileNames.ToList();
          }
          pbBox.Image = Image.FromFile(ImageFilenames[0]);
        }
        if (ImageFilenames.Count > 0)
             nTotalNumber = ImageFilenames.Count; 
     }
     private void btnPrevious_Click(object sender, EventArgs e)
     {
         nCurrentItem--;
         if (nCurrentItem < 0)
            nCurrentItem = 0;
            
         else if (nCurrentItem < nTotalNumber)
             pbBox.Image = Image.FromFile(ImageFilenames[nCurrentItem]);
      }
      private void btnNext_Click(object sender, EventArgs e)
      {
          nCurrentItem++;
          if (nCurrentItem > nTotalNumber)
            nCurrentItem = nTotalNumber;
            
          else if (nCurrentItem < nTotalNumber)
              pbBox.Image = Image.FromFile(ImageFilenames[nCurrentItem]);
       }
