            public static void TestPlayerEx()
            {
                PlayerEx plex = new PlayerEx();
                plex.Done += new PlayerEx.DoneEventHandler(plex_Done);
                Mp3Reader mr = new Mp3Reader(File.OpenRead("in.mp3"));
                IntPtr format = mr.ReadFormat();
                byte[] data = mr.ReadData();
                mr.Close();
                plex.OpenPlayer(format);
                plex.AddData(data);
                plex.StartPlay();
            }
            
            static void plex_Done(object sender, DoneEventArgs e)
            {
                if (e.IsEndPlaying)
                {
                    ((PlayerEx)sender).ClosePlayer();
                }
            }
             
