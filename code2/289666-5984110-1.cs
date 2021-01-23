    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (radioDegrees.Checked) { CalcDegrees(); }
                if (radioDistance.Checked) { CalcDistance(); }
            }
    
            private void radioDegrees_CheckedChanged(object sender, EventArgs e)
            {
                CalcDegrees();
            }
    
            private void radioDistance_CheckedChanged(object sender, EventArgs e)
            {
                CalcDistance();
            }
    
            private void CalcDegrees()
            {
                if (!string.IsNullOrEmpty(tbA.Text)) { FtoC(); return; }
                if (!string.IsNullOrEmpty(tbB.Text)) { CtoF(); return; }
            }
    
            private void CalcDistance()
            {
                if (!string.IsNullOrEmpty(tbA.Text)) { InchToCent(); return; }
                if (!string.IsNullOrEmpty(tbB.Text)) { CentToInch(); return; }
            }
    
            private void FtoC()
            {
                 tbB.Text = Convert.ToString((Convert.ToDouble(tbA.Text) * 9 / 5) + 32); 
            }
    
            private void CtoF()
            {
                tbA.Text = Convert.ToString((Convert.ToDouble(tbB.Text) - 32) * 5 / 9); 
            }
    
            private void InchToCent()
            {
                tbB.Text = Convert.ToString(Convert.ToDouble(tbA.Text) * 2.54);             
                
            }
    
            private void CentToInch()
            {
                tbA.Text = Convert.ToString(Convert.ToDouble(tbB.Text) * 0.3937008); 
            }
        }
