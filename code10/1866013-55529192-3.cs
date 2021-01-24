    public class LifeDemandData
    {
        public string DEMAND { get; set; }
        public string PREMIUM { get; set; }
        public string LATEFEE { get; set; }
        public bool ROWCHECK { get; set; }
        public ICommand CheckedCommand {  set; get; }
    }
