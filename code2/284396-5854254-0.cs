      MessageBoxButton[] mbs = new[]
                                         {
                                             MessageBoxButton.OK,
                                             MessageBoxButton.OKCancel, 
                                             MessageBoxButton.YesNo,
                                             MessageBoxButton.YesNoCancel
                                         };
            MessageBoxImage[] mbi = new[]
                                        {
                                            MessageBoxImage.Asterisk, MessageBoxImage.Error, MessageBoxImage.Exclamation,
                                            MessageBoxImage.Hand, MessageBoxImage.Information, MessageBoxImage.None,
                                            MessageBoxImage.Question, MessageBoxImage.Stop, MessageBoxImage.Warning
                                        };
            MessageBox.Show("Message Text", "Message Title", mbs[2], mbi[4]);
