       private void Form1_Shown(object sender, EventArgs e)
        {
            Stream sr = Assembly.GetExecutingAssembly().GetManifestResourceStream("namespace.file.swf");
            if (sr == null) return;
            var reader = new BufferedStream(sr);
            string tempfile = Path.GetTempFileName() + ".swf";
            var data = new byte[reader.Length];
            reader.Read(data, 0, (int)reader.Length);
            File.WriteAllBytes(tempfile, data);
            webBrowser1.Url = new Uri(tempfile);
        }
