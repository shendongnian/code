    namespace WpfApplication1
    {
    
    public partial class MainWindow : Window
    {    
        public MainWindow()
        {
            InitializeComponent();
            List<int> ids = new List<int>() { 1, 2, 3 };
            this.TestListView.ItemsSource = GetAllNameDoc(ids);
        }
        public List<Docs> GetAllNameDoc(List<int> ids)
        {
            List<Docs> docs = new List<Docs>();
            foreach (int r in ids)
            {
                docs.Add(new Docs() { Id = r, DocName = GetNameDoc(r) });
            }
            return docs;
        }
        private string GetNameDoc(int id)
        {
            return "SomeDocName";
        }
        
    }
    public class Docs
    {
        public int Id { get; set; }
        public string DocName { get; set; }
    }
    }
