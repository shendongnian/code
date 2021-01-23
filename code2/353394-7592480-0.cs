     using (AutoResetEvent are = new AutoResetEvent(false))
     {
      System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
       {
         MemoryStream byteStream = new MemoryStream(resp);
         byteStream.Write(resp, 0, resp.Length);
         string[] iconname = entry.Name.Split(new char[] { '-' });
         string newimagename = iconname[1];
             
         Uri icon_url = new Uri(newimagename, UriKind.RelativeOrAbsolute);
         icon = new BitmapImage(icon_url);
         imag = new Image();
         imag.Source = icon;
         sourceofImage = icon.UriSource.ToString();
         icon.SetSource(byteStream);
         Console.WriteLine(icon.PixelHeight + ":" + icon.PixelWidth);
         are.Set();
         // string[] newname = entry.Name.Split(new char[] { '-', '.' });
        // iconDict.Add(sourceofImage, icon);
        });
        are.WaitOne();
        string[] newname = entry.Name.Split(new char[] { '-', '.' });
        string newFileName = newname[1];
        iconDict.Add(newFileName, icon);
       }
