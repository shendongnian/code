       public partial class ProcessAnimals : Form
        {
            public ProcessAnimals()
            {
                InitializeComponent();
            }
    
            private void processAnimals_Click(object sender, EventArgs e)
            {
                CreatureStorage.Add("Animal", 1);
            }
        }
