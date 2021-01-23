    public partial class Form1 : Form
    {
        private FlashCard _flashCard;
        public Form1()
        {
            InitializeComponent();
        }
        private void btnPrvious_Click(object sender, EventArgs e)
        {
            DisplayPrevious();
        }
        private void DisplayPrevious()
        {
            FlashText.Text = _flashCard.GetPreviousLine();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // This could go under somewhere like a load new flash card button or
            // menu option etc.
            try
            {
                _flashCard = new FlashCard(@"c:\temp\EnglishFlashCard.txt");
            }
            catch (Exception)
            {
               // do something
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            DisplayNext();
        }
        private void DisplayNext()
        {
            FlashText.Text = _flashCard.GetNextLine();
        }
    }
