    public class Distance
    {
        public int FromBuildingId { get; set; }
        public int ToBuildingId { get; set; }
        public double TotalMiles { get; set; }
        public Distance(int fromBuildingId, int toBuildingId, double totalMiles)
        {
            FromBuildingId = fromBuildingId;
            ToBuildingId = toBuildingId;
            TotalMiles = totalMiles;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Distance;
            return other != null &&
                (other.FromBuildingId == FromBuildingId && other.ToBuildingId == ToBuildingId) ||
                (other.FromBuildingId == ToBuildingId && other.ToBuildingId == FromBuildingId);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return 17 * (FromBuildingId.GetHashCode() + ToBuildingId.GetHashCode());
            }
        }
    }
