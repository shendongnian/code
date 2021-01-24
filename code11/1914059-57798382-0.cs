    public List<Metadata> ExtractMetaDataExifTool(string filepath, string ExifToolPath)
        {
            #region ReadFromFile
            string output = "";
            var lstMetadata = new List<Metadata>();
            using (var p = new Process())
            {
                // exiftool command
                string toolPath = "";
                toolPath += " -s ";
                toolPath += "-fast -G -t -m -q -q -n ";
                toolPath += "\"" + filepath + "\"";
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                startInfo.FileName = "\"" + ExifToolPath + "\\exiftool.exe" + "\"";
                startInfo.Arguments = toolPath;
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                p.StartInfo = startInfo;
                bool status = p.Start();
                StringBuilder q = new StringBuilder();
                while (!p.HasExited)
                {
                    q.Append(p.StandardOutput.ReadToEnd());
                }
                output = q.ToString();
                p.WaitForExit();
            }
            #endregion ReadFromFile
            #region ExtractFileMetadataFromString
            while (output.Length > 0)
            {
                int epos = output.IndexOf('\r');
                if (epos < 0)
                    epos = output.Length;
                string tmp = output.Substring(0, epos);
                int tpos1 = tmp.IndexOf('\t');
                int tpos2 = tmp.IndexOf('\t', tpos1 + 1);
                if (tpos1 > 0 && tpos2 > 0)
                {
                    string taggroup = tmp.Substring(0, tpos1);
                    ++tpos1;
                    string tagname = tmp.Substring(tpos1, tpos2 - tpos1);
                    ++tpos2;
                    string tagvalue = tmp.Substring(tpos2, tmp.Length - tpos2);
                    // special processing for tags with binary data 
                    tpos1 = tagvalue.IndexOf(", use -b option to extract");
                    if (tpos1 >= 0)
                        tagvalue.Remove(tpos1, 26);
                    if (!string.IsNullOrEmpty(taggroup) && !string.IsNullOrEmpty(tagname) && !string.IsNullOrEmpty(tagvalue))
                    {
                        lstMetadata.Add(new Metadata
                        {
                            group = taggroup?.Trim(),
                            name = tagname?.Trim(),
                            value = tagvalue?.Trim()
                        });
                    }
                }
                // is \r followed by \n ?
                if (epos < output.Length)
                    epos += (output[epos + 1] == '\n') ? 2 : 1;
                output = output.Substring(epos, output.Length - epos);
            }
            #endregion ExtractFileMetadataFromString
            return lstMetadata;
        }
