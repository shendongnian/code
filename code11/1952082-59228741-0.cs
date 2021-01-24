    namespace Schiffe_versenken
    {
      public partial class Einzelspieler : Form
      {       
        public Einzelspieler(int Übergabe_Darkmode)
        {
            InitializeComponent();
            this.MaximizeBox = false; 
            this.MinimizeBox = false;
            darkmode = Übergabe_Darkmode;
        }
        
        private int darkmode { get; set; }
        private void Einzelspieler_Load(object sender, EventArgs e)
        {
            if(darkmode == 1)
            {
                MessageBox.Show("Hui");
            }
