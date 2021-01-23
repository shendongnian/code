    public class MyModel {
        [ScaffoldColumn(false)]
        public int CharityId { get; set; }
    
        public SelectList Charities { get; set; }
    }
