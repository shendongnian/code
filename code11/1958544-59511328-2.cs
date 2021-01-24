      var t = ImageToByteArray(pictureBox5.Image);
      var b = ImageToByteArray(Uny.Properties.Resources.Uny_Slider_one);
      if( CheckIfEqual(t,b) )
      {
          MessageBox.Show("Equal");
      }
      else
      {
          MessageBox.Show("Not Equal");
      }
