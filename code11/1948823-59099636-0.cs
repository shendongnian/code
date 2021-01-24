        private int isWorking;
        private System.Threading.Timer decodingTimer;
        private ZXing.IBarcodeReader<BitmapSource> reader = new ZXing.Presentation.BarcodeReader();
        
        private void VlcControl_Loaded(object sender, RoutedEventArgs e)
        {
            ((VlcControl)sender).SourceProvider.CreatePlayer(new DirectoryInfo(@"C:\Program Files\VideoLAN\VLC"));
            ((VlcControl)sender).SourceProvider.MediaPlayer.SetMedia(new FileInfo(@"How Barcodes Work - YouTube.mp4"));
            ((VlcControl)sender).SourceProvider.MediaPlayer.Play();
            decodingTimer = new System.Threading.Timer(DoDecoding, null, 500, 500);
        }
        
        private void DoDecoding(object state)
        {
            if (Interlocked.Increment(ref isWorking) == 1)
            {
                this.Dispatcher.BeginInvoke((Action) (() =>
                {
                    try
                    {
                        var bitmap = vlcControl.SourceProvider.VideoSource as InteropBitmap;
                        if (bitmap != null)
                        {
                            var result = reader.Decode(bitmap);
                            if (result != null)
                            {
                                MessageBox.Show(result.Text);
                            }
                        }
                    }
                    catch (Exception )
                    {
                        // add handling here
                    }
                    finally
                    {
                        Interlocked.Decrement(ref isWorking);
                    }
                }));
            }
            else
            {
                Interlocked.Decrement(ref isWorking);
            }
        }
