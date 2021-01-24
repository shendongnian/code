    public class ApiViewModel : BaseViewModel
    {
        public bool CustomerIsChecked { get; set; }
        public bool StorageIsChecked { get; set; }
        public bool ArticlesIsChecked { get; set; }
        public bool Transfer  // <- remove ()
        {
            get   // it should have a getter.
            {
                if(CustomerIsChecked == true)
                {
                    return true; 
                }
                return false;
            }
        }
        public override string ToString()
        {
            return Transfer().ToString(); 
        }
    }
