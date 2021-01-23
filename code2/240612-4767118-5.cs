    	private SynchronizationContext _context = SynchronizationContext.Current;
        void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            using (Image<Bgr, byte> frame = capture.QueryFrame())
            {
                if (frame != null)
                {
                    this._context.Send(o => 
                        {
                            using (var stream = new MemoryStream())
                            {
								// My way to display frame 
                                frame.Bitmap.Save(stream, ImageFormat.Bmp);
                                BitmapImage bitmap = new BitmapImage();
                                bitmap.BeginInit();
                                bitmap.StreamSource = new MemoryStream(stream.ToArray());
                                bitmap.EndInit();
                                webcam.Source = bitmap;
                            }
                            
                        }, 
						null);
                }
            }
        }
