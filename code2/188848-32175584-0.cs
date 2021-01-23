    using Hjg.Pngcs;  // https://code.google.com/p/pngcs/
    using Hjg.Pngcs.Chunks;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace MarkerGenerator.Utils
    {
        class PngUtils
        {
    
            public string getMetadata(string file, string key)
            {
    
                PngReader pngr = FileHelper.CreatePngReader(file);
                //pngr.MaxTotalBytesRead = 1024 * 1024 * 1024L * 3; // 3Gb!
                //pngr.ReadSkippingAllRows();
                string data = pngr.GetMetadata().GetTxtForKey(key);
                pngr.End();
                return data; ;
            }
    
    
            public static void addMetadata(String origFilename, Dictionary<string, string> data)
            {
                String destFilename = "tmp.png";
                PngReader pngr = FileHelper.CreatePngReader(origFilename); // or you can use the constructor
                PngWriter pngw = FileHelper.CreatePngWriter(destFilename, pngr.ImgInfo, true); // idem
                //Console.WriteLine(pngr.ToString()); // just information
                int chunkBehav = ChunkCopyBehaviour.COPY_ALL_SAFE; // tell to copy all 'safe' chunks
                pngw.CopyChunksFirst(pngr, chunkBehav);          // copy some metadata from reader 
                foreach (string key in data.Keys)
                {
                    PngChunk chunk = pngw.GetMetadata().SetText(key, data[key]);
                    chunk.Priority = true;
                }
    
                int channels = pngr.ImgInfo.Channels;
                if (channels < 3)
                    throw new Exception("This example works only with RGB/RGBA images");
                for (int row = 0; row < pngr.ImgInfo.Rows; row++)
                {
                    ImageLine l1 = pngr.ReadRowInt(row); // format: RGBRGB... or RGBARGBA...
                    pngw.WriteRow(l1, row);
                }
                pngw.CopyChunksLast(pngr, chunkBehav); // metadata after the image pixels? can happen
                pngw.End(); // dont forget this
                pngr.End();
                File.Delete(origFilename);
                File.Move(destFilename, origFilename);
    
            }
    
            public static void addMetadata(String origFilename,string key,string value)
            {
                Dictionary<string, string> data = new Dictionary<string, string>();
                data.Add(key, value);
                addMetadata(origFilename, data);
            }
    
    
        }
    }
