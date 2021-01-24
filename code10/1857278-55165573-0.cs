    public partial class Form1 : Form
    {
        public Form1()
    {
        InitializeComponent();
    }
    private async void button1_Click(object sender, EventArgs e)
    {
        button1.BackColor = Color.Lime;
        button1.Refresh();
        await awaiting();
        button1.BackColor = Color.DarkGreen;
    }
    private async Task awaiting() {
            await Task.Delay(5000);
        }
    }
         
