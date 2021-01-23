    interface IDonutRepository
    {
        public IEnumerable<Donut> GetDonuts();
        public IEnumerable<Donut> GetDonuts(bool showStale);
    }
