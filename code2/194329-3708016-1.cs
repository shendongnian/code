    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            MyFirendsList  = new Dictionary<string, Friends>();
            MyFirendsList.Add("1", new Friends() { Friend_guid = Guid.NewGuid().ToString(),Name = "Saurabh" });
            MyFirendsList.Add("2", new Friends() { Friend_guid = Guid.NewGuid().ToString(), Name = "Nitya" });
            this.DataContext = this;
            
        }
        public Dictionary<string, Friends> MyFirendsList { get; set; }
        private void Friend_chat_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
              MessageBox.Show((sender as ComboBox).SelectedValue.ToString());
        }
    }
    public class Friends
    {
        public string Friend_guid { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public string FriendAvatar { get; set; }
        public string Status { get; set; }
        public string Status_Image { get; set; }
        
    } 
