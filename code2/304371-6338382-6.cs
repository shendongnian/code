    ImageBrush ibImage100 = new ImageBrush() { /*assign the image100.jpg image*/ };
    ImageBrush ib900image = new ImageBrush() { /*assign the 900image.jpg image*/ };
    
         private void Honey_Started(object sender, ManipulationStartedEventArgs e)
         {
            
               if (Honey.Fill == ibImage100)
               {
                    Honey.Fill = ib900image;
               }
         } 
           
