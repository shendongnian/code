    var virtualFileDataObject = new VirtualFileDataObject(
                    // BeginInvoke ensures UI operations happen on the right thread
                    (vfdo) => Dispatcher.BeginInvoke((Action)(() => BusyScreen.Visibility = Visibility.Visible)),
                    (vfdo) => Dispatcher.BeginInvoke((Action)(() => BusyScreen.Visibility = Visibility.Collapsed)));
    
                // Provide a virtual file (downloaded on demand), its URL, and descriptive text
                virtualFileDataObject.SetData(new VirtualFileDataObject.FileDescriptor[]
                {
                    new VirtualFileDataObject.FileDescriptor
                    {
                        Name = "DelaysBlog.xml",
                        StreamContents = stream =>
                            {
                                using(var webClient = new WebClient())
                                {
                                    var data = webClient.DownloadData("http://blogs.msdn.com/delay/rss.xml");
                                    stream.Write(data, 0, data.Length);
                                }
                            }
                    },
                });
                virtualFileDataObject.SetData(
                    (short)(DataFormats.GetDataFormat(CFSTR_INETURLA).Id),
                    Encoding.Default.GetBytes("http://blogs.msdn.com/delay/rss.xml\0"));
                virtualFileDataObject.SetData(
                    (short)(DataFormats.GetDataFormat(DataFormats.Text).Id),
                    Encoding.Default.GetBytes("[The RSS feed for Delay's Blog]\0"));
    
                DoDragDropOrClipboardSetDataObject(e.ChangedButton, TextUrl, virtualFileDataObject, DragDropEffects.Copy);
 
