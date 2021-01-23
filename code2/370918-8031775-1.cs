    public partial class Form1 : Form
    {
        ContextMenu _menu = new ContextMenu();
        public Form1()
        {
            InitializeComponent();
            ContextMenu = _menu;
            _menu.Popup += new EventHandler(_menu_Popup);
            _menu.Collapse += new EventHandler(_menu_Collapse);
            _menu.MenuItems.Add(new MenuItem() { Text = "Test" });
            Timer a = new Timer() { Interval = 3000 };
            a.Tick += (sender, e) =>
            {
                _menu.MenuItems.Add(new MenuItem() { Text = "Woah!" });
                if (_menuPoppedUp)
                    _menu.Show(this, Point.Empty);
            };
            a.Start();
        }
        bool _menuPoppedUp;
        void _menu_Collapse(object sender, EventArgs e)
        {
            _menuPoppedUp = false;
        }
        void _menu_Popup(object sender, EventArgs e)
        {
            _menuPoppedUp = true;
        }
    }
