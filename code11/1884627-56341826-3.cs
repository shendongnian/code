    public class BarcodeScanner : IBarcodeScanner
    {
        /// <summary>
        /// The callback, it only makes sense for one client at a time
        /// </summary>
        private static Action<string> _callback; // <--- NEW
        public async Task<bool> ClaimScannerAsync()
        {
            // as per OP's post, not reproduced here
        }
        public void Subscribe(Action<string> callback) // <--- NEW
        {
            // it makes sense to have only one foreground barcode reader client at a time
            _callback = callback;
        }
        public void Unsubscribe() // <--- NEW
        {
            _callback = null;
        }
        private void ClaimedBarcodeScanner_DataReceivedAsync(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
        {
            if (_callback == null) // don't bother with ConvertBinaryToString if we don't need to
                return;
            // all we need do here is convert to a string and pass it to the client
            var barcode = CryptographicBuffer.ConvertBinaryToString(BinaryStringEncoding.Utf8,
                                                                    args.Report.ScanDataLabel);
            _callback(barcode);
        }
    }
