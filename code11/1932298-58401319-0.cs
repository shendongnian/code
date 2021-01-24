    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ZXing;
    
    namespace SeparatorPageSplit.framework
    {
        class QRCodeScanner
        {
            //BarcodeReader reader;
            QRCodeDecoderLibrary.QRDecoder QRCodeDecoder;
    
            public QRCodeScanner()
            {
                try
                {
                    QRCodeDecoder = new QRCodeDecoderLibrary.QRDecoder();
                }
                catch (Exception ex)
                {
                    Program.WriteToLogFile(ex.ToString());
                }
            }
            public Boolean IsQRCodeFound(string ImagePath)
            {
                string decoded = "";
                Bitmap bitmap = new Bitmap(ImagePath);
                try
                {
                    byte[][] DataByteArray = QRCodeDecoder.ImageDecoder(bitmap);
                    decoded = QRCodeResult(DataByteArray);
                }
                catch (Exception ex)
                {
                    Program.WriteToLogFile(ex.ToString());
                }
                finally
                {
                    bitmap.Dispose();
                }
    
                if (decoded == "CCA001")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
    
            /// <summary>
            /// Format result for display
            /// </summary>
            /// <param name="DataByteArray"></param>
            /// <returns></returns>
            private static string QRCodeResult(byte[][] DataByteArray)
            {
                // no QR code
                if (DataByteArray == null) return string.Empty;
    
                // image has one QR code
                if (DataByteArray.Length == 1) return ForDisplay(QRCodeDecoderLibrary.QRDecoder.ByteArrayToStr(DataByteArray[0]));
    
                // image has more than one QR code
                StringBuilder Str = new StringBuilder();
                for (int Index = 0; Index < DataByteArray.Length; Index++)
                {
                    if (Index != 0) Str.Append("\r\n");
                    Str.AppendFormat("QR Code {0}\r\n", Index + 1);
                    Str.Append(ForDisplay(QRCodeDecoderLibrary.QRDecoder.ByteArrayToStr(DataByteArray[Index])));
                }
                return Str.ToString();
            }
    
            private static string ForDisplay(string Result)
            {
                int Index;
                for (Index = 0; Index < Result.Length && (Result[Index] >= ' ' && Result[Index] <= '~' || Result[Index] >= 160); Index++) ;
                if (Index == Result.Length) return Result;
    
                StringBuilder Display = new StringBuilder(Result.Substring(0, Index));
                for (; Index < Result.Length; Index++)
                {
                    char OneChar = Result[Index];
                    if (OneChar >= ' ' && OneChar <= '~' || OneChar >= 160)
                    {
                        Display.Append(OneChar);
                        continue;
                    }
    
                    if (OneChar == '\r')
                    {
                        Display.Append("\r\n");
                        if (Index + 1 < Result.Length && Result[Index + 1] == '\n') Index++;
                        continue;
                    }
    
                    if (OneChar == '\n')
                    {
                        Display.Append("\r\n");
                        continue;
                    }
    
                    Display.Append('¿');
                }
                return Display.ToString();
            }
        }
    }
