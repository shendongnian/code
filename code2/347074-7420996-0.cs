    List<Image> images;
        
    void GetImagesIntoAList()
    {
        List<Image> images = new List<Image>();
    
        DirectoryInfo dir = new DirectoryInfo(@"D:\somedir");
                    FileInfo[] files = dir.GetFiles();
        
                    foreach (var item in files)
                    {                        
                       FileStream stream = new FileStream(item.FullName, FileMode.Open, FileAccess.Read);
                       Image i = new Image();
                       BitmapImage src = new BitmapImage();
                       src.BeginInit();
                       src.StreamSource = stream;
                       src.EndInit();
                       i.Source = src;
                       images.Add(i);
                    }
    
       Thread rotator = new Thread(rotate);
       rotator.Start();
    }
    
    void rotate()
    {
       foreach(var img in images)
       {
          Dispatcher.BeginInvoke( () => 
          { 
             nameOfImageControlOnAWindow.Source = img;
             Thread.Sleep(5000);
          }
          );
       }
    }
