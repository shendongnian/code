     public partial class Document : Page
    {
        
        LibraryDataAccess.Model1 model;
       
        List<LibraryDataAccess.Model.Document> list;
        public Document()
        {
            model = new Model1();
            list = new List<LibraryDataAccess.Model.Document>();
            list = model.Documents.ToList();
            InitializeComponent();
            list.Add(new LibraryDataAccess.Model.Document { Id = 1, PublisherId = 2, Title = "sdfs" });
            grid_doc.ItemsSource = list;
        }
        public class viewmodel : List<KeyValuePair<string,string>>
        {
       
        public viewmodel()
        {
            
            this.Add(new KeyValuePair<string, string>(1.ToString(), "s"));
            this.Add(new KeyValuePair<string, string>(2.ToString(), "t"));
        }
        }
