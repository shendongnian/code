    public class GtfsFileDownloader
    {
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public byte[] ZipBytes { get; set; }
    
        public GtfsFileDownloader(string loc, string nm)
        {
            FileLocation = loc;
            FileName = nm;
        }
    
        public void DownloadZip()
        {
            ZipBytes = new WebClient().DownloadData(FileLocation + FileName);
        }
    
        public List<T> GetFileContents<T, Q>(string fileName) where Q: ClassMap
        {
            var retList = new List<T>();
            using (var ZipStream = new MemoryStream(ZipBytes)) {
                var entry = new ZipArchive(ZipStream).Entries.SingleOrDefault(x => x.FullName == fileName);
                if(entry != null)
                {
                    using (var reader = new StreamReader(entry.Open()))
                    {
                        using (var csv = new CsvReader(reader))
                        {
                            csv.Configuration.HeaderValidated = null;
                            csv.Configuration.MissingFieldFound = null;
                            csv.Configuration.RegisterClassMap<Q>();
                            try
                            {
                                retList = csv.GetRecords<T>().ToList();
                            }
                            catch(CsvHelperException ex)
                            {
                                throw new System.Exception(ex.Message);
                            }
                        }
                    }
                }
            }
            return retList;
        }
    }
