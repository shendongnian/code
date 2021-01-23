    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using iTextSharp.text;
    using iTextSharp.text.pdf.qrcode;
    using iTextSharp.text.pdf.codec;
    /*
       Class rewritted to Convert ByteMatrix to BMP image by rewritting GetImage method
    from ITextSharp 
    author: Luis Claudio Souza
    */
    namespace iTextSharp.text.pdf{
    /**
     * A QRCode implementation based on the zxing code.
     * @author Paulo Soares
     * @since 5.0.2
     */
    public class BarcodeQRCode {
        ByteMatrix bm;
        /**
         * Creates the QR barcode. The barcode is always created with the smallest possible     size and is then stretched
         * to the width and height given. Set the width and height to 1 to get an unscaled barcode.
         * @param content the text to be encoded
         * @param width the barcode width
         * @param height the barcode height
         * @param hints modifiers to change the way the barcode is create. They can be EncodeHintType.ERROR_CORRECTION
         * and EncodeHintType.CHARACTER_SET. For EncodeHintType.ERROR_CORRECTION the values can be ErrorCorrectionLevel.L, M, Q, H.
         * For EncodeHintType.CHARACTER_SET the values are strings and can be Cp437, Shift_JIS and ISO-8859-1 to ISO-8859-16. The default value is
         * ISO-8859-1.
         * @throws WriterException
         */
        public BarcodeQRCode(String content, int width, int height, IDictionary<EncodeHintType, Object> hints) {
            QRCodeWriter qc = new QRCodeWriter();
            bm = qc.Encode(content, width, height, hints);
        }
        private byte[] GetBitMatrix() {
            int width = bm.GetWidth();
            int height = bm.GetHeight();
            int stride = (width + 7) / 8;
            byte[] b = new byte[stride * height];
            sbyte[][] mt = bm.GetArray();
            for (int y = 0; y < height; ++y) {
                sbyte[] line = mt[y];
                for (int x = 0; x < width; ++x) {
                    if (line[x] != 0) {
                        int offset = stride * y + x / 8;
                        b[offset] |= (byte)(0x80 >> (x % 8));
                    }
                }
            }
            return b;
        }
        /** Gets an <CODE>Image</CODE> with the barcode.
         * @return the barcode <CODE>Image</CODE>
         * @throws BadElementException on error
         */
        public void GetImage()
        {
            sbyte[][] imgNew = bm.GetArray();
            Bitmap bmp1 = new Bitmap(bm.GetWidth(), bm.GetHeight());
            Graphics g1 = Graphics.FromImage(bmp1);
            g1.Clear(Color.White);
            for (int i = 0; i <= imgNew.Length - 1; i++)
            {
                for (int j = 0; j <= imgNew[i].Length - 1; j++)
                {
                    if (imgNew[j][i] == 0)
                    {
                        g1.FillRectangle(Brushes.Black, i, j, 1, 1);
                    }
                    else
                    {
                        g1.FillRectangle(Brushes.White, i, j, 1, 1);
                    }
                }
            }
            bmp1.Save("D:\\QREncode.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
 
        }
        }
    }
