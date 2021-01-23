    System.Drawing.Image image = System.Drawing.Image.FromStream( 
        new System.IO.MemoryStream((byte[]) SqlReader["img_data"]) 
    );
    
    int width = image.Width;
    int height = image.Height;
