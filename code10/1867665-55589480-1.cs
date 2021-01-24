    public class SearchParams {
        public int ID;
        public string Name;
        public string City;
        public SearchParams(int ID = null, string Name = null, string City = null)
        { 
             this.ID = ID;
             this.Name = Name;
             this.City = City;    
        }
    }
    public function getEmpInfo(SearchParams params){
        // build query by that parameters
        if(ID != null){
           // add query by ID
        }
    }
