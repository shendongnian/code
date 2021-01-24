        class RatingDto : IComparable<RatingDto>
        {
            public int RatingTypeId { get; set; }
            public string RatingType { get; set; }
            public string Rating { get; set; }
            public int CompareTo(RatingDto  other)
            {
                if (this.RatingTypeId != other.RatingTypeId)
                {
                    return this.RatingTypeId.CompareTo(other.RatingTypeId);
                }
                else
                {
                    return this.RatingType.CompareTo(other.RatingType);
                }
            }
        }
