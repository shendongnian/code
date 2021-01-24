public partial class MainWindow : Window
  private ZXing.IBarcodeReader<BitmapSource> reader = new                ZXing.Presentation.BarcodeReader();
        private System.Threading.Timer decodingTimer;
and
    private void DoDecoding(object state)
        {
            this.Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    InteropBitmap bitmap = videoSin.SourceProvider.VideoSource as    InteropBitmap;
                    if (bitmap != null)
                    {
                        var result = reader.Decode(bitmap);
                        if (result != null)
                        {
                            MessageBox.Show(result.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
             ));
        }  
The Video stream works and I only get the error when I present a barcode to the camara.
   Thanks     
