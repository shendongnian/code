                                bMediaError = true; 
				autoResetEvent.Set();
                            };
			hiddenMediaElement.MediaOpened += (obj, Sender) =>
                            {  
				// I think this occurs when it is successfull. Else put it in the handler that handles a success
				autoResetEvent.Set();
                            };
			 
			autoResetEvent.WaitOne(); // set a timeout value
                        if (!bMediaError)
                        {
                            ObjChildMediaPlayer.Visibility = Visibility.Visible;
                            ObjChildMediaPlayer._currenTitle = strTitle;
                            ObjChildMediaPlayer.Show();
                            Content_FullScreenChanged(null, null);
                        }
