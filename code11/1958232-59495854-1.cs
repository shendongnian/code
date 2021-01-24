     public class Tree
       {
        public int Id { get; set; }
        public DateTime? createdDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string Parent { get; set; } // Activities
        public int? ParentId { get; set; } // parentid
        public string Label { get; set; }
        public string Filename { get; set; }
        public string ImagePath { get; set; }
        public string ThumbPath { get; set; }
        public Collections w2ui {get; set;}
    }
    public class Collections
    {
        [JsonProperty("children", NullValueHandling = NullValueHandling.Ignore)]
        public IList<Tree> Child { get; set; } = new List<Tree>();
     }
