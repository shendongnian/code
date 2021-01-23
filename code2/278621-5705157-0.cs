    class PlantRankings
    {
        public Plant Plant { get; set; }
        public double PhSuitabilityScore { get; set; }
        public double SoilTypeScore { get; set; }
        public double SmellsNiceScore { get; set; }
        public double RankingScore { get; set; } // could compute on-the-fly here
    }
