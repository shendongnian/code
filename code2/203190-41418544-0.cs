    private void btnReload_Click(object sender, EventArgs e)
        {
            byte[] fileContent = File.ReadAllBytes(Application.StartupPath + @"\yourflashfile.swf");
            
            if (fileContent != null && fileContent.Length > 0)
            {
                using (MemoryStream stm = new MemoryStream())
                {
                    using (BinaryWriter writer = new BinaryWriter(stm))
                    {
                        /* Write length of stream for AxHost.State */
                        writer.Write(8 + fileContent.Length);
                        /* Write Flash magic 'fUfU' */
                        writer.Write(0x55665566);
                        /* Length of swf file */
                        writer.Write(fileContent.Length);
                        writer.Write(fileContent);
                        stm.Seek(0, SeekOrigin.Begin);
                        /* 1 == IPeristStreamInit */
                        //Same as LoadMovie()
                        this.axShockwaveFlash1.OcxState = new AxHost.State(stm, 1, false, null);
                    }
                }
                fileContent = null;
                GC.Collect();
            }
        }
