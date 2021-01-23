    Dictionary<Image,string> UrlDicationary = new Dictionary<Image, string>();
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
         if(e.ColumnIndex == 3)
         {
             Image image = dataGridView1[e.ColumnIndex, e.RowIndex].Value as Image;
             if(image != null)
             {
                   string url;
                   if(UrlDicationary.TryGetValue(image, out url))
                   {
                            // do something with your url
                   }
             }
         }
    }
