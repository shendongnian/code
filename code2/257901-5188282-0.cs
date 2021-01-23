    public partial class Form1 : Form
    {
       public Form1()
       {
          InitializeComponent();
          listView1.View = View.Details;
          listView1.HideSelection = false;
       }
    
       private void textBox1_TextChanged(object sender, EventArgs e)
       {
          foreach (ListViewItem item in listView1.Items)
          {
             if (item.Text == textBox1.Text)
             {
                item.BackColor = Color.LightSteelBlue;
                return;
             }
          }
       }
    
       private void textBox1_Leave(object sender, EventArgs e)
       {
          this.textBox1.Focus();
       }
    }
