    hiddenMediaElement.Source = new Uri(strMediaFileName, UriKind.RelativeOrAbsolute); 
    hiddenMediaElement.MediaFailed += (obj, Sender) => 
    {  
        ObjChildMediaPlayer.Visibility = Visibility.Visible; 
        ObjChildMediaPlayer._currenTitle = strTitle; 
        ObjChildMediaPlayer.Show(); 
        Content_FullScreenChanged(null, null); 
    }; 
