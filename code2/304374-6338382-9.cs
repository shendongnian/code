    BitmapImage biImage100 = new BitmapImage(new Uri("/Jar/image100.jpg",UriKind.Relative));
    ImageBrush ibImage100 = new ImageBrush() { ImageSource = biImage100 };
    ImageBrush ib900image = new ImageBrush() { /*assign the 900image.jpg image*/ };
    
         private void Honey_Started(object sender, ManipulationStartedEventArgs e)
         {
            
               if (Honey.Fill == ibImage100)
               {
                    Honey.Fill = ib900image;
               }
         } 
           
