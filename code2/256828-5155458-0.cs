    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            ComboBox box = (ComboBox)toolStripComboBox1.Control;
            box.DrawMode = DrawMode.OwnerDrawVariable;
            box.MeasureItem += new MeasureItemEventHandler(box_MeasureItem);
            box.DrawItem += new DrawItemEventHandler(box_DrawItem);
        }
        void box_DrawItem(object sender, DrawItemEventArgs e) {
            // etc..
        }
        void box_MeasureItem(object sender, MeasureItemEventArgs e) {
            // etc..
            
        }
    }
