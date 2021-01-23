    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    namespace CropImageToCircle
    {
        //Browse Image
        private void button1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Choose Image(*.jpg;,*.jpeg;,*.png;)|*.jpg;,*.jpeg;,*.png;";
            if(ofd.ShowDialog()== DialogResult.OK)
            {
                pictureBox1.Image =Image.FromFile( ofd.FileName);
            }
        }
        //CropToCircle
        private void button2_Click(object sender, EventArgs e)
        {
           
            var imageHelper = new ImageHelper();
           pictureBox2.Image= imageHelper.CropImage(pictureBox1.Image);
        }
        //Save Image
        private void button3_Click(object sender, EventArgs e)
        {
            var imageHelper = new ImageHelper();
            var sfd = new SaveFileDialog();
            sfd.FileName = "*";
            sfd.DefaultExt = "png";
            sfd.Filter = "Png Image (.png)|*.png ";
            sfd.ValidateNames = true;
            sfd.FilterIndex = 1;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                imageHelper.SaveImage(pictureBox2.Image,sfd.FileName,ImageFormat.Png);
            }
            
        }
    }
}
