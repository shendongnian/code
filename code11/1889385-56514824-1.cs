    public class CategoryRollupViewModel
    {
    
        public CategoryRollupViewModel(CategoryRollup item){
          ID = item.ID;
          CategoryChildID = item.CategoryChildren.Select(x=> x.ID).ToList();
          CategoryParentID = item.CategoryParent?.ID; 
        }
        [Key]
        public int ID { get; set; }
    
        public List<int> CategoryChildID { get; set; }
    
        public int CategoryParentID { get; set; }
    
    }
