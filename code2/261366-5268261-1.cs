        public class State
        {
            public string FileName;
            public MemoryStream stream;
        }
        public void Run()
        {
            string unpackDirectory = "c:\\temp\\";
            string zipToUnpack = "c:\\test\\1000.zip";
            var ConvertImage = new WaitCallback( (o) => {
                    State s = o as State;
                    try
                    {
                        var bm = new Bitmap(s.stream);
                        var f = unpackDirectory + s.FileName.ToLower().Replace(".bmp", ".jpg");
                        bm.Save(f, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("File: " + s.FileName + " " + ex.ToString());
                    }
                });
            using (ZipFile zip = ZipFile.Read(zipToUnpack))
            {
                foreach (ZipEntry e in zip)
                {
                    if (e.FileName.ToLower().IndexOf(".bmp") > 0)
                    {
                        var ms = new MemoryStream();
                        e.Extract(ms);
                        ThreadPool.QueueUserWorkItem ( ConvertImage, 
                                                       new State {
                                                           FileName = e.FileName, stream = ms }
                                                       });                      
                    }
                }
            }
        }
