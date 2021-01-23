    class Program
    {
        static unsafe void Main(string[] args)
        {
            var baseStream = new MemoryStream();
            var tw = new StreamWriter(baseStream, Encoding.UTF8);
            using (var bmpSrc = new Bitmap(Image.FromFile(@"label.png")))
            {
                tw.WriteLine(ZplImage.GetGrfStoreCommand("R:LBLRA2.GRF", bmpSrc));
            }
            tw.WriteLine(ZplImage.GetGrfPrintCommand("R:LBLRA2.GRF"));
            tw.WriteLine(ZplImage.GetGrfDeleteCommand("R:LBLRA2.GRF"));
            tw.Flush();
            baseStream.Position = 0;
            var gdipj = new GdiPrintJob("ZEBRA S4M-200dpi ZPL", GdiPrintJobDataType.Raw, "Raw print", null);
            gdipj.WritePage(baseStream);
            gdipj.CompleteJob();
        }
    }
    class ZplImage
    {
        public static string GetGrfStoreCommand(string filename, Bitmap bmpSource)
        {
            if (bmpSource == null)
            {
                throw new ArgumentNullException("bmpSource");
            }
            validateFilename(filename);
            var dim = new Rectangle(Point.Empty, bmpSource.Size);
            var stride = ((dim.Width + 7) / 8);
            var bytes = stride * dim.Height;
            using (var bmpCompressed = bmpSource.Clone(dim, PixelFormat.Format1bppIndexed))
            {
                var result = new StringBuilder();
                result.AppendFormat("^XA~DG{2},{0},{1},", stride * dim.Height, stride, filename);
                byte[][] imageData = GetImageData(dim, stride, bmpCompressed);
                byte[] previousRow = null;
                foreach (var row in imageData)
                {
                    appendLine(row, previousRow, result);
                    previousRow = row;
                }
                result.Append(@"^FS^XZ");
                return result.ToString();
            }
        }
        public static string GetGrfDeleteCommand(string filename)
        {
            validateFilename(filename);
            return string.Format("^XA^ID{0}^FS^XZ", filename);
        }
        public static string GetGrfPrintCommand(string filename)
        {
            validateFilename(filename);
            return string.Format("^XA^FO0,0^XG{0},1,1^FS^XZ", filename);
        }
        static Regex regexFilename = new Regex("^[REBA]:[A-Z0-9]{1,8}\\.GRF$");
        private static void validateFilename(string filename)
        {
            if (!regexFilename.IsMatch(filename))
            {
                throw new ArgumentException("Filename must be in the format "
                    + "R:XXXXXXXX.GRF.  Drives are R, E, B, A.  Filename can "
                    + "be alphanumeric between 1 and 8 characters.", "filename");
            }
        }
        unsafe private static byte[][] GetImageData(Rectangle dim, int stride, Bitmap bmpCompressed)
        {
            byte[][] imageData;
            var data = bmpCompressed.LockBits(dim, ImageLockMode.ReadOnly, PixelFormat.Format1bppIndexed);
            try
            {
                byte* pixelData = (byte*)data.Scan0.ToPointer();
                byte rightMask = (byte)(0xff << (data.Stride * 8 - dim.Width));
                imageData = new byte[dim.Height][];
                for (int row = 0; row < dim.Height; row++)
                {
                    byte* rowStart = pixelData + row * data.Stride;
                    imageData[row] = new byte[stride];
                    for (int col = 0; col < stride; col++)
                    {
                        byte f = (byte)(0xff ^ rowStart[col]);
                        f = (col == stride - 1) ? (byte)(f & rightMask) : f;
                        imageData[row][col] = f;
                    }
                }
            }
            finally
            {
                bmpCompressed.UnlockBits(data);
            }
            return imageData;
        }
        private static void appendLine(byte[] row, byte[] previousRow, StringBuilder baseStream)
        {
            if (row.All(r => r == 0))
            {
                baseStream.Append(",");
                return;
            }
            if (row.All(r => r == 0xff))
            {
                baseStream.Append("!");
                return;
            }
            if (previousRow != null && MatchByteArray(row, previousRow))
            {
                baseStream.Append(":");
                return;
            }
            byte[] nibbles = new byte[row.Length * 2];
            for (int i = 0; i < row.Length; i++)
            {
                nibbles[i * 2] = (byte)(row[i] >> 4);
                nibbles[i * 2 + 1] = (byte)(row[i] & 0x0f);
            }
            for (int i = 0; i < nibbles.Length; i++)
            {
                byte cPixel = nibbles[i];
                int repeatCount = 0;
                for (int j = i; j < nibbles.Length && repeatCount <= 400; j++)
                {
                    if (cPixel == nibbles[j])
                    {
                        repeatCount++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (repeatCount > 2)
                {
                    if (repeatCount == nibbles.Length - i
                        && (cPixel == 0 || cPixel == 0xf))
                    {
                        if (cPixel == 0)
                        {
                            if (i % 2 == 1)
                            {
                                baseStream.Append("0");
                            }
                            baseStream.Append(",");
                            return;
                        }
                        else if (cPixel == 0xf)
                        {
                            if (i % 2 == 1)
                            {
                                baseStream.Append("F");
                            }
                            baseStream.Append("!");
                            return;
                        }
                    }
                    else
                    {
                        baseStream.Append(getRepeatCode(repeatCount));
                        i += repeatCount - 1;
                    }
                }
                baseStream.Append(cPixel.ToString("X"));
            }
        }
        private static string getRepeatCode(int repeatCount)
        {
            if (repeatCount > 419)
                throw new ArgumentOutOfRangeException();
            int high = repeatCount / 20;
            int low = repeatCount % 20;
            const string lowString = " GHIJKLMNOPQRSTUVWXY";
            const string highString = " ghijklmnopqrstuvwxyz";
            string repeatStr = "";
            if (high > 0)
            {
                repeatStr += highString[high];
            }
            if (low > 0)
            {
                repeatStr += lowString[low];
            }
            return repeatStr;
        }
        private static bool MatchByteArray(byte[] row, byte[] previousRow)
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] != previousRow[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
    internal static class NativeMethods
    {
        #region winspool.drv
        #region P/Invokes
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool OpenPrinter(string szPrinter, out IntPtr hPrinter, IntPtr pd);
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool ClosePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern UInt32 StartDocPrinter(IntPtr hPrinter, Int32 level, IntPtr di);
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool EndDocPrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool StartPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool EndPagePrinter(IntPtr hPrinter);
        [DllImport("winspool.Drv", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool WritePrinter(
            // 0
            IntPtr hPrinter,
            [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] pBytes,
            // 2
            UInt32 dwCount,
            out UInt32 dwWritten);
        #endregion
        #region Structs
        [StructLayout(LayoutKind.Sequential)]
        internal struct DOC_INFO_1
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string DocName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string OutputFile;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string Datatype;
        }
        #endregion
        #endregion
    }
    /// <summary>
    /// Represents a print job in a spooler queue
    /// </summary>
    public class GdiPrintJob
    {
        IntPtr PrinterHandle;
        IntPtr DocHandle;
        /// <summary>
        /// The ID assigned by the print spooler to identify the job
        /// </summary>
        public UInt32 PrintJobID { get; private set; }
        /// <summary>
        /// Create a print job with a enumerated datatype
        /// </summary>
        /// <param name="PrinterName"></param>
        /// <param name="dataType"></param>
        /// <param name="jobName"></param>
        /// <param name="outputFileName"></param>
        public GdiPrintJob(string PrinterName, GdiPrintJobDataType dataType, string jobName, string outputFileName)
            : this(PrinterName, translateType(dataType), jobName, outputFileName)
        {
        }
        /// <summary>
        /// Create a print job with a string datatype
        /// </summary>
        /// <param name="PrinterName"></param>
        /// <param name="dataType"></param>
        /// <param name="jobName"></param>
        /// <param name="outputFileName"></param>
        public GdiPrintJob(string PrinterName, string dataType, string jobName, string outputFileName)
        {
            if (string.IsNullOrWhiteSpace(PrinterName))
                throw new ArgumentNullException("PrinterName");
            if (string.IsNullOrWhiteSpace(dataType))
                throw new ArgumentNullException("PrinterName");
            IntPtr hPrinter;
            if (!NativeMethods.OpenPrinter(PrinterName, out hPrinter, IntPtr.Zero))
                throw new Win32Exception();
            this.PrinterHandle = hPrinter;
            NativeMethods.DOC_INFO_1 docInfo = new NativeMethods.DOC_INFO_1()
            {
                DocName = jobName,
                Datatype = dataType,
                OutputFile = outputFileName
            };
            IntPtr pDocInfo = Marshal.AllocHGlobal(Marshal.SizeOf(docInfo));
            RuntimeHelpers.PrepareConstrainedRegions();
            try
            {
                Marshal.StructureToPtr(docInfo, pDocInfo, false);
                UInt32 docid = NativeMethods.StartDocPrinter(hPrinter, 1, pDocInfo);
                if (docid == 0)
                    throw new Win32Exception();
                this.PrintJobID = docid;
            }
            finally
            {
                Marshal.FreeHGlobal(pDocInfo);
            }
        }
        /// <summary>
        /// Write the data of a single page or a precomposed PCL document
        /// </summary>
        /// <param name="data"></param>
        public void WritePage(Stream data)
        {
            if (data == null)
                throw new ArgumentNullException("data");
            if (!data.CanRead && !data.CanWrite)
                throw new ObjectDisposedException("data");
            if (!data.CanRead)
                throw new NotSupportedException("stream is not readable");
            if (!NativeMethods.StartPagePrinter(this.PrinterHandle))
                throw new Win32Exception();
            byte[] buffer = new byte[0x14000]; /* 80k is Stream.CopyTo default */
            uint read = 1;
            while ((read = (uint)data.Read(buffer, 0, buffer.Length)) != 0)
            {
                UInt32 written;
                if (!NativeMethods.WritePrinter(this.PrinterHandle, buffer, read, out written))
                    throw new Win32Exception();
                if (written != read)
                    throw new InvalidOperationException("Error while writing to stream");
            }
            if (!NativeMethods.EndPagePrinter(this.PrinterHandle))
                throw new Win32Exception();
        }
        /// <summary>
        /// Complete the current job
        /// </summary>
        public void CompleteJob()
        {
            if (!NativeMethods.EndDocPrinter(this.PrinterHandle))
                throw new Win32Exception();
        }
        #region datatypes
        private readonly static string[] dataTypes = new string[] 
        { 
            // 0
            null, 
            "RAW", 
            // 2
            "RAW [FF appended]",
            "RAW [FF auto]",
            // 4
            "NT EMF 1.003", 
            "NT EMF 1.006",
            // 6
            "NT EMF 1.007", 
            "NT EMF 1.008", 
            // 8
            "TEXT", 
            "XPS_PASS", 
            // 10
            "XPS2GDI" 
        };
        private static string translateType(GdiPrintJobDataType type)
        {
            return dataTypes[(int)type];
        }
        #endregion
    }
    public enum GdiPrintJobDataType
    {
        Unknown = 0,
        Raw = 1,
        RawAppendFF = 2,
        RawAuto = 3,
        NtEmf1003 = 4,
        NtEmf1006 = 5,
        NtEmf1007 = 6,
        NtEmf1008 = 7,
        Text = 8,
        XpsPass = 9,
        Xps2Gdi = 10
    }
