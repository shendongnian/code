            if (DspFle == "None")
                return true;
            List<string> DspFle = DspFleName.Split(',');
            List<string> ActualFiles = new List<string>();
            foreach (string file in Directory.GetFiles(ExportDirectory)
            {
                DirectoryInfo di = new DirectoryInfo(file);
                ActualFiles.Add(di.Name);            
            }
            foreach (string file in DspFle)
            {
                if (!ActualFiles.Contains(dspFile))
                    return false;
            }
            return true;
