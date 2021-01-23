    Image old;
    old = Image.Load("file.bmp"); //I don't currently have MSDN at hand, nor I remember how to load the bitmap
    Image new = new Image{ Width = old.Width; Height = old.Height };
    for (i=0; i<old.Width-1; i++)
        for (j=0; j<old.Height; j++)
        {
            Color p = old[i,j];
            byte gray = (p.R+p.G+p.B)/3;
            new[i,j] = new Color(gray,gray,gray);
        }
     }
     pictureBox.Image = new;
