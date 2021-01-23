        public static Bitmap CreateImage(byte[] myData)
        {
            int i = 0;
            int ss = 0;
            float xpos = 0;
            float ESCKxpos = 0;
            float yposStep = 8;
            float ypos = 0;
            int p1 = 0;
            int p2 = 0;
            Font fn = null;
            Font fnw = null;
            Font fdw = null;
            Bitmap pg = new Bitmap(600, 600);
            Graphics gr = Graphics.FromImage(pg);
            SolidBrush sb = new SolidBrush(Color.Black);
            gr.FillRectangle(new SolidBrush(Color.White), 0, 0, pg.Width, pg.Height);
            xpos = 0;
            ypos = 0;
            try
            {
                i = 8;
                fnw = new Font("Courier New", i--, FontStyle.Regular);
                while (fnw.GetHeight() > 8)
                    fnw = new Font("Courier New", i--, FontStyle.Regular);
                i = 16;
                fdw = new Font("Courier New", i--, FontStyle.Regular);
                while (fdw.GetHeight() > 16)
                    fdw = new Font("Courier New", i--, FontStyle.Regular);
                fn = fnw;
                //
                // Read the stream of bytes, use a state machine 
                // to interpretate the various codes
                //
                i = 0;
                while (i < myData.Length)
                {
                    switch (ss)
                    {
                        case 0:
                            switch (myData[i])
                            {
                                case 10: // Line feed
                                    ypos += yposStep;
                                    break;
                                case 13: // Carrige return
                                    xpos = 0;
                                    break;
                                case 14: // SO
                                    break;
                                case 27: // ESC sequence
                                    ss = 100;
                                    break;
                                default:
                                    p1 = 0;
                                    break;
                            }
                            break;
                        case 100:
                            //
                            // Escape sequence
                            //
                            switch (myData[i])
                            {
                                case (byte)'A': // ESC A, select line spacing
                                    ss = 110;
                                    break;
                                case (byte)'K': // ESC K, bitmap image
                                    ss = 120;
                                    break;
                                case (byte)'W': // ESC W, select font width
                                    ss = 130;
                                    break;
                                default:
                                    p1 = 0;
                                    break;
                            }
                            break;
                        case 110: // ESC A n, n/60-inch line spacing
                            // Ignore this
                            ss = 0;
                            break;
                        case 120: // ESC K, bitmap image
                            p1 = myData[i];
                            ss = 121;
                            break;
                        case 121: // ESC K, bitmap image
                            p2 = myData[i];
                            p2 *= 256;
                            p2 += p1;
                            if (p2 < 1)
                            {
                                ss = 0;
                            }
                            else
                            {
                                ESCKxpos = xpos;
                                ss = 122;
                            }
                            break;
                        case 122: // ESC K, bitmap image
                            {
                                int z;
                                for (int y = 0; y < 8; y++)
                                {
                                    z = 1 << y;
                                    if ((myData[i] & z) != 0)
                                    {
                                        gr.FillRectangle(sb, xpos, ypos+(7 - y), 1, 1);
                                    }
                                }
                                xpos++;
                                p2--;
                                if (p2 < 1)
                                {
                                    ss = 0;
                                    xpos = ESCKxpos;
                                }
                            }
                            break;
                        case 130:// ESC W n, Set the printer font to normal or double width
                            if ((myData[i] == 1) || (myData[i] == 49))
                            {
                                fn = fdw;
                                yposStep = 16;
                            }
                            else
                            {
                                fn = fnw;
                                yposStep = 8;
                            }
                            ss = 0;
                            break;
                    }
                    i++;
                }
            }
            catch { }
            return pg;
        } // public static Bitmap CreateImage(byte[] myData)
