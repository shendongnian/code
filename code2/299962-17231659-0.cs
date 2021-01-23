    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms; // reference is added manually.
    namespace ctt // Clipboard Types Tester
    {
        class Program
        {
            [STAThread] // it is important! Without this Clipboard.GetDataObject() returns null. 
            static void Main()
            {
                // 'formatsAll' is from http://www.radsoftware.com.au/articles/clipboardmonitor.aspx
                string[] formatsAll = new string[] 
		        {
			        DataFormats.Bitmap,
			        DataFormats.CommaSeparatedValue,
			        DataFormats.Dib,
			        DataFormats.Dif,
			        DataFormats.EnhancedMetafile,
			        DataFormats.FileDrop,
			        DataFormats.Html,
			        DataFormats.Locale,
			        DataFormats.MetafilePict,
			        DataFormats.OemText,
			        DataFormats.Palette,
			        DataFormats.PenData,
			        DataFormats.Riff,
			        DataFormats.Rtf,
			        DataFormats.Serializable,
			        DataFormats.StringFormat,
			        DataFormats.SymbolicLink,
			        DataFormats.Text,
			        DataFormats.Tiff,
			        DataFormats.UnicodeText,
			        DataFormats.WaveAudio
		        };
                IDataObject data = Clipboard.GetDataObject();
                if (data == null)
                    System.Console.WriteLine("Error!");
                else
                {
                    bool empty = true;
                    foreach (string format in formatsAll)
                        if (data.GetDataPresent(format))
                        {
                            empty = false;
                            break;
                        }
                    if (empty) System.Console.WriteLine("Now clipboard is empty.");
                    else
                    {
                        System.Console.WriteLine("Now clipboard contains the following types:");
                        System.Console.WriteLine();
                        foreach (string format in formatsAll)
                            if (data.GetDataPresent(format))
                                System.Console.WriteLine(format);
                    }
                }
                System.Console.ReadKey();
            }
        }
    }
