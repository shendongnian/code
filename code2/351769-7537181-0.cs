    public class SampleData{
    
        static ObservableCollection<Product> teams = null;
        static public ObservableCollection<Product> Teams{
            get{
                if(teams == null)
                    teams = GetSampleData();
                return teams;
            }
            set{
                teams = value;
            }
        }
    
        // make this one private
        private static ObservableCollection<Product> GetSampleData(){
            ObservableCollection<Product> t = new ObservableCollection<Product>();
            // fill t with your data
            return t;
        }
    }
