    internal class RecurringClusterModel
    {
        public string REC_Cluster_1 { get; set; }
        public string REC_Cluster_2 { get; set; }
        public string REC_Cluster_3 { get; set; }
        public IEnumerable<string> Clusters => GetAllClusters();
        private IEnumerable<string> GetAllClusters()
        {
            if (!string.IsNullOrEmpty(REC_Cluster_1))
                yield return REC_Cluster_1;
            if (!string.IsNullOrEmpty(REC_Cluster_2))
                yield return REC_Cluster_2;
            if (!string.IsNullOrEmpty(REC_Cluster_3))
                yield return REC_Cluster_3;
        }
    }
