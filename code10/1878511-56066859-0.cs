    public class UnpivotData {
        public Guid Id { get; set; }
        public string ResourceName { get; set; }
        public string LanguageID { get; set; }
        public string Translation { get; set; }
        
        public UnpivotData() => Id = Guid.NewGuid();
    
        public UnpivotData ShallowCopy() {
            var ans = (UnpivotData)this.MemberwiseClone();
            ans.Id = Guid.NewGuid();
            return ans;
        }
    }
