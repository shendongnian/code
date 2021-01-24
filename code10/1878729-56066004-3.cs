    public class Form1 : Form
    {
        // At the form class level
        NumericUpDown[] numCtrls = new NumericUpDown[]
        {
            numericUpDown1RB1Rep, numericUpDown1RB2Rep,
            numericUpDown1RB3Rep, numericUpDown1RB4Rep
        };
        
        public Form1()
        {
             InitializeComponent();
        }
    
        ... other form's methods or events.....
    
    }
