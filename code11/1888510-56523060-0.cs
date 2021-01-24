cs
public JsonResult GetFiles(string MCodeID)
        {
            if (MCodeID == null)
            {
                throw new ArgumentNullException(nameof(MCodeID));
            }
            List<Files> filelist = new List<Files>();
            //Searching Files in //192.168.1.191
            string path = @"\\192.168.1.191\Materials Project\";
            string searchPattern = MCodeID + "*";
            //string[] files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);
            DirectoryInfo fi = new DirectoryInfo(path);
            int FCodeID = 0;
            foreach (var file in fi.GetFiles(searchPattern, SearchOption.AllDirectories))
            {
                filelist.Add(new Files
                {
                    FCodeID = FCodeID,
                    FDescr = file.Name
                });
                FCodeID += 1;
            }
            filelist.Insert(0, new Files { FCodeID = 0, FDescr = "--Select File--" });
            return Json(new SelectList(filelist, "FCodeID", "FDescr"));
}
