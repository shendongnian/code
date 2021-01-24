    class TransactionEntity : TableEntity
    {
        public String s{ get; set; }
        public Int32 r { get; set; }
        public String e{ get; set; }
        public String t{ get; set; }
        public String l{ get; set; }
        public TransactionEntity(){//do nothing}
        public TransactionEntity(String id, String s, String e, String t)
        {
            this.r= 0;
            this.s= s;
            this.RowKey = id;
            this.PartitionKey = Guid.NewGuid().ToString();
            this.e= e == null ? "" : e;
            this.t= t== null ? "" : t;
        }
    }
