        public static Boolean CheckContents(string ExportDirectory, string DspFleName)
        {
            if (DspFleName == "None")
                return true;
            var DspFle = DspFleName.Split(',');
            var ActualFiles = Directory.GetFiles(ExportDirectory);
            
            foreach(var file in DspFle)
                if (!ActualFiles.Any(x=>Path.GetFileName(x).Equals(file)))
                    return false;
            return true;
        }
