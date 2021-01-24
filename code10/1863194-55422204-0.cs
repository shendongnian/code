    public class RootObject
    {
        ...
        public Dictionary<string, CompetitorResult> competitor_results { get; set; }
        ...
    }
    public class CompetitorResult
    {
        public string rank_type { get; set; }
        public int? rank { get; set; }
        public object position_places_image { get; set; }
        public int? position_organic { get; set; }
        public int? position_local_pack { get; set; }
        public object position_knowledge_panel { get; set; }
        public object position_featured_snippet { get; set; }
        public object[] position_change_cache { get; set; }
        public int last_week_change { get; set; }
        public int last_month_change { get; set; }
        public int last_day_change { get; set; }
    }
