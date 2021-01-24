         // this functions reads binary audio data from a cd and stores it in a jagged array called TrackData
        // it uses only low level file io calls to open and read the Table of Content and then the binary 'music' data sector by sector
        // as discovered from the table of content
        // it also writes it to a binary file called tracks with not extension
        // this file can be read by any decent hex editor
        void readcd()
        {
            bool TocValid = false;
            IntPtr cdHandle = IntPtr.Zero;
            CDROM_TOC Toc = null;
            int track, StartSector, EndSector;
            BinaryWriter bw;
            bool CDReady;
            uint uiTrackCount, uiTrackSize, uiDataSize;
            int i;
            uint BytesRead, Dummy;
            char Drive = (char)cmbDrives.Text[0];
            TRACK_DATA td;
            int sector;
            byte[] SectorData;
            IntPtr pnt;
            Int64 Offset;
 
            btnStart.Enabled = false;
 
            Dummy = 0;
            BytesRead = 0;
            CDReady = false;
 
            Toc = new CDROM_TOC();
            IntPtr ip = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(Toc)));
            Marshal.StructureToPtr(Toc, ip, false);
            // is it a cdrom drive
            DriveTypes dt = GetDriveType(Drive + ":\\");
            if (dt == DriveTypes.DRIVE_CDROM)
            {
                // get a Handle to control the drive with
                cdHandle = CreateFile("\\\\.\\" + Drive + ':', GENERIC_READ, FILE_SHARE_READ, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                CDReady = DeviceIoControl(cdHandle, IOCTL_STORAGE_CHECK_VERIFY, IntPtr.Zero, 0, IntPtr.Zero, 0, ref Dummy, IntPtr.Zero) == 1;
                if (!CDReady)
                {
                    MessageBox.Show("Drive Not Ready", "Drive Not Ready", MessageBoxButtons.OK);
 
                }
                else
                {
                    uiTrackCount = 0;
                    // is the Table of Content valid?
                    TocValid = DeviceIoControl(cdHandle, IOCTL_CDROM_READ_TOC, IntPtr.Zero, 0, ip, (uint)Marshal.SizeOf(Toc), ref BytesRead, IntPtr.Zero) != 0;
                    //fetch the data from the unmanaged pointer back to the managed structure
                    Marshal.PtrToStructure(ip, Toc);
                    if (!TocValid)
                    {
                        MessageBox.Show("Invalid Table of Content ", "Invalid Table of Content ", MessageBoxButtons.OK);
                    }
                    else
                    {
                        // really only nescary if there are un-useable tracks
                        uiTrackCount = Toc.LastTrack;
                        //for (i = Toc.FirstTrack - 1; i < Toc.LastTrack; i++)
                        //{
                        //    if (Toc.TrackData[i].Control == 0)
                        //        uiTrackCount++;
                        //}
                        // create a jagged array to store the track data
                        TrackData = new byte[uiTrackCount][];
                       
 
                        // read all the tracks
                        for (track = 1; track <= uiTrackCount; track++)//uiTrackCount; track++)
                        {
                            Offset = 0;// used to store Sectordata into trackdata
                            label1.Text = "Reading Track" + track.ToString() + " of " + uiTrackCount.ToString(); ;
                            Application.DoEvents();
                            // create a binary writer to write the track data
                            bw = new BinaryWriter(File.Open(Application.StartupPath + "\\Track" + track.ToString (), FileMode.Create));
 
                            //The CDROM_TOC-structure contains the FirstTrack (1) and the LastTrack (max. track nr). CDROM_TOC::TrackData[0] contains info of the
                            //first track on the CD. Each track has an address. It represents the track's play-time using individual members for the hour, minute,
                            //second and frame. The "frame"-value (Address[3]) is given in 1/75-parts of a second -> Remember: 75 frames form one second and one
                            //frame occupies one sector.
 
                            //Find the first and last sector of the track
                            td = Toc.TrackData[track - 1];
                            //              minutes                   Seconds       fractional seconds     150 bytes is the 2 second lead in to track 1
                            StartSector = (td.Address_1 * 60 * 75 + td.Address_2 * 75 + td.Address_3) - 150;
                            td = Toc.TrackData[track];
                            EndSector = (td.Address_1 * 60 * 75 + td.Address_2 * 75 + td.Address_3) - 151;
                            progressBar1.Minimum = StartSector;
                            progressBar1.Maximum = EndSector;
                            uiTrackSize = (uint)(EndSector - StartSector) * CB_AUDIO;//CB_AUDIO==2352
                            // how big is the track
                            uiDataSize = (uint)uiTrackSize;
                            //Allocate for the track
                            TrackData[track - 1] = new byte[uiDataSize];
                            SectorData = new byte[CB_AUDIO * NSECTORS];
 
                            // read all the sectors for this track
                            for (sector = StartSector; (sector < EndSector); sector += NSECTORS)
                            {
                                Debug.Print(sector.ToString("X2"));
                                RAW_READ_INFO rri = new RAW_READ_INFO();// contains info about the sector to be read
                                rri.TrackMode = TRACK_MODE_TYPE.CDDA;
                                rri.SectorCount = (uint)1;
                                rri.DiskOffset = sector * CB_CDROMSECTOR;
                                //get a pointer to the structure
                                Marshal.StructureToPtr(rri, ip, false);
                                // allocate an unmanged pointer to hold the data read from the disc
                                int size = Marshal.SizeOf(SectorData[0]) * SectorData.Length;
                                pnt = Marshal.AllocHGlobal(size);
 
                                //Sector data is a byte array to hold data from each sector data
                                // initiallize it to all zeros
                                SectorData.Initialize();
 
 
                                // read the sector
                                i = DeviceIoControl(cdHandle, IOCTL_CDROM_RAW_READ, ip, (uint)Marshal.SizeOf(rri), pnt, (uint)NSECTORS * CB_AUDIO, ref BytesRead, IntPtr.Zero);
                                if (i == 0)
                                {
                                    MessageBox.Show("Bad Sector Read", "Bad Sector Read from sector " + sector.ToString("X2"), MessageBoxButtons.OK);
                                    break;
                                }
                                progressBar1.Value = sector;                             // return the pointers to their respective managed data sources
                                Marshal.PtrToStructure(ip, rri);
                                Marshal.Copy(pnt, SectorData, 0, SectorData.Length);
 
                                Marshal.FreeHGlobal(pnt);
                                Array.Copy(SectorData, 0, TrackData[track - 1], Offset, BytesRead);
                                Offset += BytesRead;
                            }
 
                            // write the binary data nad then close it
                            bw.Write(TrackData[track - 1]);
                            bw.Close();
                        }
                        //unlock
                        PREVENT_MEDIA_REMOVAL pmr = new PREVENT_MEDIA_REMOVAL();
                        pmr.PreventMediaRemoval = 0;
                        ip = Marshal.AllocHGlobal((IntPtr)(Marshal.SizeOf(pmr)));
                        Marshal.StructureToPtr(pmr, ip, false);
                        DeviceIoControl(cdHandle, IOCTL_STORAGE_MEDIA_REMOVAL, ip, (uint)Marshal.SizeOf(pmr), IntPtr.Zero, 0, ref Dummy, IntPtr.Zero);
                        Marshal.PtrToStructure(ip, pmr);
                        Marshal.FreeHGlobal(ip);
                    }
                }
            }
            //Close the CD Handle
            CloseHandle(cdHandle);
            ConvertToWav();
        }  
