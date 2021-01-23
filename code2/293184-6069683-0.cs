    public void SaveAs()
        {
            SaveFileDialog diag = new SaveFileDialog();
            DialogResult dr = diag.ShowDialog();
            if (dr.Equals(DialogResult.OK))
            {
                string _filename = diag.FileName;
                // filename not specified. Use FileName = ...
                if (_filename == null || _filename.Length == 0)
                    throw new Exception("Unspecified file name");
                // cannot override RO file
                if (File.Exists(_filename)
                    && (File.GetAttributes(_filename)
                    & FileAttributes.ReadOnly) != 0)
                    throw new Exception("File exists and is read-only!");
                // check supported image formats
                ImageFormat format = FormatFromExtension(_filename);
                if (format == null)
                    throw new Exception("Unsupported image format");
                // JPG images get special treatement
                if (format.Equals(ImageFormat.Jpeg))
                {
                    EncoderParameters oParams = new EncoderParameters(1);
                    oParams.Param[0] = new EncoderParameter(
                        System.Drawing.Imaging.Encoder.Quality, 100L);
                    ImageCodecInfo oCodecInfo = GetEncoderInfo("image/jpeg");
                    yourImage.Save(_filename, oCodecInfo, oParams);
                }
                else
                    yourImage.Save(_filename, format);
            }
        }
