    public partial class Form1 : Form
    {
        private SoundPlayer playrock = new SoundPlayer(Properties.Resources.rock1);
		
        public Form1()
        {
            InitializeComponent();
        }
        private void ButtonWTVClick(object sender, EventArgs e)
        {
            playrock.Play();
        }
    }
