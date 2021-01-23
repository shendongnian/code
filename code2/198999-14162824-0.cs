        public List<MediaFileInfo> GetDuplicatePictures()
        {
            List<MediaFileInfo> dupes = new List<MediaFileInfo>();
            var grpDupes = from f in _fileRepo
                           group f by f.Length into grps
                           where grps.Count() >1
                           select grps;
            foreach (var item in grpDupes)
            {
                foreach (var thing in item)
                {
                    dupes.Add(thing);
                }
            }
            return dupes;
        }
