    class MagicPerformer
    {
        public int Param1 { get; set; }
        public string Param2 { get; set; }
        public DateTime Param3 { get; set; }
        public MagicPerformer SetParam1(int value) { this.Param1 = value; return this; }
        public MagicPerformer SetParam2(string value) { this.Param2 = value; return this; }
        public MagicPerformer SetParam4(DateTime value) { this.Param3 = value; return this; }
        public void DoMagic() // Uses all the parameters and does the magic
        {
        }
    }
