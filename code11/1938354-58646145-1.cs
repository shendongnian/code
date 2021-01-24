    namespace crossplatformapp  
    {  
    public partial class MainPage : ContentPage  
    {  
        public List<Contacts> tempdata;  
        public MainPage()  
        {  
            InitializeComponent();  
            data();  
            list.ItemsSource = tempdata;  
              
        }  
  
        public void data()  
        {  
            // all the temp data  
            tempdata = new List<Contacts> {  
                new Contacts(){ Name = "umair", Num = "2323423"},  
                new Contacts(){ Name = "saleh", Num = "23423"},  
                new Contacts(){ Name = "umair", Num = "233423423"},  
                new Contacts(){ Name = "sanat", Num = "2423"},  
                new Contacts(){ Name = "jawad", Num = "323423"},  
                new Contacts(){ Name = "shan", Num = "2323423"},  
                new Contacts(){ Name = "ahmed", Num = "2323423"},  
                new Contacts(){ Name = "abc", Num = "2323423"},  
                new Contacts(){ Name = "umair", Num = "2323423"},  
                new Contacts(){ Name = "etc", Num = "2323423"},  
            };  
        }  
  
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)  
        {  
            //thats all you need to make a search  
  
            if (string.IsNullOrEmpty(e.NewTextValue))  
            {  
                list.ItemsSource = tempdata;  
            }  
  
            else  
            {  
                list.ItemsSource = tempdata.Where(x => 
     x.Name.StartsWith(e.NewTextValue));  
            }  
        }  
    }  
