                var writer = new ZXing.BarcodeWriter
                {
                    Format = ZXing.BarcodeFormat.QR_CODE,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = 0,
                        Width = 0,
                        Margin = 0
                    },
                };
                var barcodeImage = writer.Write("<your content here>");
