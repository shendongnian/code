    public enum Category { Electronic, ClothBased, // etc. }
    abstract class HouseholdItem { 
        private readonly Category category;
        public Category Category { get; }
        public HouseholdItem(Category category) {
            this.category = category;
        }
    }
    class Television : HouseholdItem {
        public Television() : base(Category.Electronic) { }
    }
    
