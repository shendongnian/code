      public partial class MainPage : ContentPage
    {
        List<string> list;
        public MainPage()
        {
            InitializeComponent();
            list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            drainxy1();
            drainxy2();
            drainxy3();
            drainxy4();
            drainlocationPicker1.SelectedIndexChanged += DrainlocationPicker1_SelectedIndexChanged;
            drainlocationPicker2.SelectedIndexChanged += DrainlocationPicker2_SelectedIndexChanged;
            drainlocationPicker3.SelectedIndexChanged += DrainlocationPicker3_SelectedIndexChanged;
            drainlocationPicker4.SelectedIndexChanged += DrainlocationPicker4_SelectedIndexChanged;
        }
        private void DrainlocationPicker4_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }
        private void DrainlocationPicker3_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            drainlocationPicker4.Items.RemoveAt(drainlocationPicker3.SelectedIndex);
        }
        private void DrainlocationPicker2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            drainlocationPicker3.Items.RemoveAt(drainlocationPicker2.SelectedIndex);
            drainlocationPicker4.Items.RemoveAt(drainlocationPicker2.SelectedIndex);
        }
        private void DrainlocationPicker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            drainlocationPicker2.Items.RemoveAt(drainlocationPicker1.SelectedIndex);
            drainlocationPicker3.Items.RemoveAt(drainlocationPicker1.SelectedIndex);
            drainlocationPicker4.Items.RemoveAt(drainlocationPicker1.SelectedIndex);
        }
        void drainxy1()
        {
            foreach (var item in list)
            {
                drainlocationPicker1.Items.Add(item);
            }
        }
        void drainxy2()
        {
            
            foreach (var item in list)
            {
                drainlocationPicker2.Items.Add(item);
            }
        }
        void drainxy3()
        {
            
            foreach (var item in list)
            {
                drainlocationPicker3.Items.Add(item);
            }
        }
        void drainxy4()
        {
           
            foreach (var item in list)
            {
                drainlocationPicker4.Items.Add(item);
            }
        }
    }
