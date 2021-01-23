    public class MyListView<T>{
        //Constructor
        public MyListView(System.Windows.Controls.ListView listView, IEnumerable<T> list)
        {
              var properties = typeof(T).GetProperties();
              foreach (var prop in properties)
              {
                  // prop = Name then SomeProperty in this case
                  // create new column in listView
                  // etc
              }
        }
    }
    
    // Example usage: Inferred type parameter 
    List<SomeObject> list = null;
    var yourListView = new MyListView(listView1, list);
    // Example usage: Explicitly specify the type parameter if it can't be inferred
    var yourListView = new MyListView<SomeObject>(listView1, null);
    
