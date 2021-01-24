public partial class CategoriesMenuDetail : ContentPage
    {
        public Dictionary<int, Btn> buttons { get; set; }
        public CategoriesMenuDetail()
        {
            InitializeComponent();
            buttons = new Dictionary<int, Btn>();
        }
        public void ButtonSelected(object sender, EventArgs e)
        {          
            var button = (Button)sender;
            if (!buttons.ContainsKey(button.GetHashCode()))
            {
                buttons.Add(button.GetHashCode(), new Btn(button));
            }
            bool state = buttons[button.GetHashCode()].Toogle();
           
            var bgColor = (state) ? Color.FromHex("#26047AD5") : Color.FromHex("#40000000");
            var borderColor = (state) ? Color.FromHex("#FF8A00") : Color.FromHex("#FFFFFF");
            button.BackgroundColor = bgColor;
            button.BorderColor = borderColor;
        }
    }
    public  class Btn
    {
        private Button _button { get; set; }
        private bool isToogle = false;
        public Btn(Button button)
        {
            _button = button;
        }
        public bool Toogle()
        {
            isToogle = !isToogle;
            return isToogle;
        }
    }
