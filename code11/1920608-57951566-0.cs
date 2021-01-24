    public void insertimage()
    {
        for (int i = 0; i <= diamond.Length -1; i++)
        {
             BitmapImage bitImg = new BitmapImage(new Uri($"ms- 
                                                  appx:///Assets/{i}.png"));
             diamond[i] = bitImg;
        }
    
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        //the index is your random index
        BitmapImage pImg = diamond[randomIndex];
        myImage.Source = pImg;
    }
