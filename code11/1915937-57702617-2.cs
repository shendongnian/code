    private void formrefresh()
    {
        FoodItem foodItem = new FoodItem();
         foodItem.ShowDialog();
         this.Close();           
    }
    
    private void BrowsImage_Click(object sender, EventArgs e)
    {
      GetFoodImage image = new GetFoodImage();
      var imagePath = image.GetImage();
      this.foodImage.Image = imagePath;
     }
        
     public string GetImage(FoodItem foodItem)
     {
         OpenFileDialog BrowseImage = new OpenFileDialog();
       
         BrowseImage.Filter = "Image Files(*.jpg; *.gif;)|*.jpg; *.gif";
        
         if (BrowseImage.ShowDialog() == DialogResult.OK)
         {
               return BrowseImage.FileName;
          }        
      }
