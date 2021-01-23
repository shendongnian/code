    public class MyCunsumerClass{
    
        // the method that uses the Team that provided by SampleData
        public void MyMethod(){
            this.flatteningTreeView.ItemsSource = SampleData.Teams;
        }
    
        public void MyFillerMethod(){
            var my_new_data = new ObservableCollection<Product>(); // or anything else you want to fill the Team with it.
            SampleData.Teams = my_new_data;
            // SampleData.Teams has new value you suplied!
        }
    
        public void MyChangerMethod(){
            var t = SampleData.Team;
            t.AnyProperty = my_value;
            t.OtherProperty = my_value_2;
            // SampleData.Team's properties changed!
        }
    
    }
