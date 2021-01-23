    public class CustomDataSource : System.Web.UI.WebControls.ObjectDataSource
    {
        public CustomDataSource()            
        {
            // Hook up the ObjectCreating event so we can use our custom object
            ObjectCreating += delegate(object sender, ObjectDataSourceEventArgs e)
                               {
                                 // Here we create our custom object that the ObjectDataSource will use
                                 e.ObjectInstance = new DataAccessor()
                               };
            }
    
    
    class DataAccessor
    {
       [DataObjectMethod(DataObjectMethodType.Insert, true)]
       public void Add(string text, string value)
       {
           // Insert logic
       }
    
       [DataObjectMethod(DataObjectMethodType.Update, true)]
       public void Update(int id, string text, string value)
       {
           // Update logic
       } 
    
       [DataObjectMethod(DataObjectMethodType.Select, true)]
       public IEnumerable<MyRadioButtonEntryWrapper> List(int filterById)
       {
           // Select logic
       }
