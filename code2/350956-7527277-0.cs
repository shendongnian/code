     var mp = ((Application.Current.RootVisual as ContentControl).Content as UserControl).Content as Indeco.SIEF.MainPage;
            Debug.Assert(mp != null); 
     Uri uri;
     uri = new Uri("/Indeco.SIEF;component/Images/Calendar/" + id.ToString() + ".png", UriKind.RelativeOrAbsolute);
     mp.dataLuna.Source = new BitmapImage(uri);
