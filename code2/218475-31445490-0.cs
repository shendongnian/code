            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            
            
            dlg.ShowDialog();
            byte[] byteArray = new byte[] { };
            if (dlg.File == null) return;
            BitmapImage bi = new BitmapImage();
            bi.CreateOptions = BitmapCreateOptions.None;
           // bi.UriSource = new Uri(@"C:\Users\saw\Desktop\image.jpg", UriKind.RelativeOrAbsolute);
            bi.SetSource(dlg.File.OpenRead());
            WriteableBitmap eb=new WriteableBitmap(bi);
