    FoodItem foodItem;
        
    private void formrefresh()
        {
             foodItem = new FoodItem();
             foodItem.ShowDialog();
             this.Close();           
        }
    
      private void BrowsImage_Click(object sender, EventArgs e)
      {
        GetFoodImage image = new GetFoodImage();
        image.GetImage(foodItem);
     }
        
        public void GetImage(FoodItem foodItem)
        {
             OpenFileDialog BrowseImage = new OpenFileDialog();
        
             BrowseImage.Filter = "Image Files(*.jpg; *.gif;)|*.jpg; *.gif";
        
             if (BrowseImage.ShowDialog() == DialogResult.OK)
             {
                  foodItem.imagePath.Text = BrowseImage.FileName;
                  filenametext = BrowseImage.FileName;
        
                  foodItem.foodImage.Image = new Bitmap(BrowseImage.FileName);
             }
        
        }
