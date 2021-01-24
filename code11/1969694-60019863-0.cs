    public partial class Form1 : Form
    {
        List<Items> STOCK;
    
        public void Form1_Load(object sender, EventArgs e)
        {
            // ...
            this.STOCK = new List<Items> { /* ... */ };
            // ...
        }
    
        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            // use this.STOCK here
        }
    }
