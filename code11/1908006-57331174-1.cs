     private void BtnCargarImagen_Click(object sender, EventArgs e)
     {
        string fileName = GetFileName();
        if(fileName != null)
        {
           PicFotografia.Image = Image.FromFile(fileName);
           MessageBox.Show("LA IMAGAN HA SIDO CARGADA");
        }
     }
     
