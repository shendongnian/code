    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    namespace ConsoleApplication1
    {
        class Program
        {
            public struct BitmapData
            {
                public int stride { get; set; }
                public int height { get; set; }
                public int width { get; set; }
                public long length { get; set; }
                public byte[] pixels { get; set; } 
            }
            public class ManagedBitmapData
            {
                public int stride { get; set; }
                public int height { get; set; }
                public int width { get; set; }
                public long length { get; set; }
                public byte[] pixels { get; set; }
            }
            static void Main(string[] args)
            {
                //source data
                List<ManagedBitmapData> managedData = new List<ManagedBitmapData>();
                IntPtr[] UnmanagedData = new IntPtr[managedData.Count];
                BitmapData[] bitMaps = new BitmapData[managedData.Count];
                for (int i = 0; i < managedData.Count; i++)
                {
                    bitMaps[i] = new BitmapData();
                    bitMaps[i].stride = managedData[i].stride;
                    bitMaps[i].height = managedData[i].height;
                    bitMaps[i].width = managedData[i].width;
                    bitMaps[i].length = managedData[i].length;
                    bitMaps[i].pixels = managedData[i].pixels;
                    Marshal.StructureToPtr(bitMaps[i], UnmanagedData[i], true);
                }
            }
        }
    }
