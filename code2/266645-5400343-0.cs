    class Record
    {
        public Record(string line) {
            string[] fields = line.Split(',');
            Field1 = fields[0];
            Field2 = fields[1];
            Field3 = fields[2];
            Field4 = fields[3];
            Field5 = fields[4];
            Field6 = fields[5];
            Field7 = fields[6].Substring(0, 1);
            Field8 = fields[6].Substring(1, 1);
            Field9 = fields[6].Substring(2, 1);
        }
        public string Field1 { get; private set; }
        public string Field2 { get; private set; }
        public string Field3 { get; private set; }
        public string Field4 { get; private set; }
        public string Field5 { get; private set; }
        public string Field6 { get; private set; }
        public string Field7 { get; private set; }
        public string Field8 { get; private set; }
        public string Field9 { get; private set; }
    }
