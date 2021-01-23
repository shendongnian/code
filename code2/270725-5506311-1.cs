    public class DownloadContentMap : ClassMap<DownloadContent>
    {
        public DownloadContentMap()
        {
            Id();
            Map(x => x.Data).CustomSqlType("BinaryBlob");
        }
    }
