            protected void WriteGraphicCtrlExt(int? delay)
        {
            Fs.WriteByte(0x21); // extension introducer
            Fs.WriteByte(0xf9); // GCE label
            Fs.WriteByte(4); // data block size
            int transp, disp;
            if (Transparent == Color.Empty)
            {
                transp = 0;
                disp = 0; // dispose = no action
            }
            else
            {
                transp = 1;
                disp = 2; // force clear if using transparent color
            }
            if (Dispose >= 0)
            {
                disp = Dispose & 7; // user override
            }
            disp <<= 2;
            // packed fields
            Fs.WriteByte(Convert.ToByte(0 | // 1:3 reserved
                                        disp | // 4:6 disposal
                                        0 | // 7   user input - 0 = none
                                        transp)); // 8   transparency flag
            WriteShort(delay ?? Delay); // delay x 1/100 sec
            Fs.WriteByte(Convert.ToByte(TransIndex)); // transparent color index
            Fs.WriteByte(0); // block terminator
        }
