    Dictionary<Image,string> UrlDicationary = new Dictionary<Image, string>();
    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
         if(e.ColumnIndex == your_image_column_index)
         {
             Image image = dataGridView1[e.ColumnIndex, e.RowIndex].Value as Image;
             if(image != null)
             {
                   string url;
                   if(UrlDicationary.TryGetValue(image, out url))
                   {
                        Process.Start(url);
                   }
             }
         }
    }
