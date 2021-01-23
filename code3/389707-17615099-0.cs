    private System.Drawing.Bitmap readfromFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] bytes = new byte[fs.Length];
            fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
            MemoryStream ms = new MemoryStream(bytes);
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(ms);
            return bmp;
        }
