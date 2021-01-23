    private void SwitchPic(BitmapImage img)
    {
        if(!img.Dispatcher.CheckAccess())
        {
            this.image1.Dispatcher.BeginInvoke(new MyDel(SwitchPic), img);
        }
        else
        {
            image1.Source = img;
        }
    }
