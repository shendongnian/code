    hiddenMediaElement.Source = new Uri(strMediaFileName, UriKind.RelativeOrAbsolute);
			hiddenMediaElement.MediaOpened += (obj, sender) =>
                            {  
				ObjChildMediaPlayer.Visibility = Visibility.Visible;
                            	ObjChildMediaPlayer._currenTitle = strTitle;
                            	ObjChildMediaPlayer.Show();
                            	Content_FullScreenChanged(null, null);
                            };
