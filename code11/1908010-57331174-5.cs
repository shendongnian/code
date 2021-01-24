     private void BtnCargarImagen_Click(object sender, EventArgs e)
     {
        string fileName = GetFileName();
        if(fileName != null)
        {
           // You may want to use PicFotografia.BackgroundImage here.
           PicFotografia.Image = Image.FromFile(fileName);
           MessageBox.Show("LA IMAGAN HA SIDO CARGADA");
        }
     }
     
