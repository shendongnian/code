    public abstract class Stage
    {
        protected long StageId { get; set; }
        public string StageName { get; set; }
        public int? Order { get; set; }
        protected Stage()
        {
            Order = 0;
        }
    }
