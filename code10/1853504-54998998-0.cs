    public class TheModel
    {
        //Can be string, int, Guid, etc. Usually this is the index key.
        public int SelectedValue {get;set;} 
        public List<SelectListItem> TheList {get;set;}
        public TheModel()
        {
            TheList = new List<SelectListItem>();
        }
    }
