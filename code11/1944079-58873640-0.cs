public Form1()
{
    InitializeComponent();
    foreach(Basket e in Form2.sas)
    {
        basketBox.Text += e.Name + Environment.NewLine;
    }
}
