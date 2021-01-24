    public partial class EditTri : Window
    {
    
        private string _key;
    
        public EditTri(string key)
        {
            _key = key;
            InitializeComponent();
      
            MessageBox.Show(key); 
        }
    
        ...
