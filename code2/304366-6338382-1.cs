    private void Honey_Started(object sender, ManipulationStartedEventArgs e)
        {
    
            if (Honey.Tag.ToString() == "image1")
            {
                ImageBrush ib = new ImageBrush();
                BitmapImage bImage = new BitmapImage(new Uri("900image.jpg",UriKind.Relative));
                ib.ImageSource = bImage;
                Honey.Fill = ib;
            }
        }
