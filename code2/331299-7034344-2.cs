    public class ParentCategory : Category
    {     
        public List<Category> SubCategories { get; set; }
        public void DoThings()
        { 
            // look at SubCategories, print something, etc
        }
    }
    
    // and then get the item to do things!
    ((ParentCategory)carListView.SelectedValue).DoThings();
