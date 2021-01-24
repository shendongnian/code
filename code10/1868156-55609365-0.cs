    public class TableStorage: TableEntity
    {
        public string CLIENTID { get; set; }
        public string REPCODE { get; set; }
        public int ENTRYNO { get; set; }
        public string DEVICEID { get; set; }
        public double LAT { get; set; }
        public double LNG { get; set; }
        public DateTime DATE_TIME { get; set; }
    
        public string PCODE { get; set; }
        public string PNAME { get; set; }
        public DateTime TXNDATE { get; set; }
        public TableStorage(){}//Added default constructor
        public TableStorage(BindData objData)
        {
            PartitionKey = objData.CLIENTID;
            RowKey = ToAzureKeyString(Guid.NewGuid().ToString());
            Timestamp = DateTimeOffset.Now;
    
            CLIENTID = objData.CLIENTID;
            REPCODE = objData.REPCODE;
            ENTRYNO = objData.ENTRYNO;
            DEVICEID = objData.DEVICEID;
            LAT = objData.LAT;
            LNG = objData.LNG;
            DATE_TIME = objData.DATE_TIME;
            PCODE = objData.PCODE;
            PNAME = objData.PNAME;
            TXNDATE = objData.TXNDATE;
        }
    
        public string ToAzureKeyString(string str)
        {
            var sb = new StringBuilder();
            foreach (var c in str
                .Where(c => c != '/'
                            && c != '\\'
                            && c != '#'
                            && c != '/'
                            && c != '?'
                            && !char.IsControl(c)))
                sb.Append(c);
            return sb.ToString();
        }
    }
