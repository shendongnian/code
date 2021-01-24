    <Button Name ="btn1" Click="Button_Click" >
      <Image x:Name="imgbtn1" Source="/Assets/1.jpg"/>
    </Button> 
    private async void Button_Click(object sender, RoutedEventArgs e)
    {            
      Image image = (Image)((Button)sender).Content;
      image.Source = new BitmapImage() { UriSource = new Uri("ms-appx:///Assets/2.png") };
    }
