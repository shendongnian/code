    // Form 1
    
    // This button creates a new "Form4" and shows it
    private void button5_Click(object sender, EventArgs e)
    {
       Form4 editItem = new Form4(this);
       editItem.Show();
    } 
    
    public string GetItemValue()
    {
       for (int i = 0; i < listView1.Items.Count; i++)
       {
          if (listView1.Items[i].Checked == true)
          {
             return listView1.Items[i].Text;
          }
       }
       return "Error";
    }
--
    // Form 2 (Form4)
    
    // Private member variable / reference to a Form1
    private Form1 _form;
    
    // Form4 Constructor: Assign the passed-in "Form1" to the member "Form1"
    public Form4(Form1 form)
    {
       this._form = form;
    }
    
    // Take the member "Form1," get the item value, and write it in the text box
    private void Form4_Load(object sender, EventArgs e)
    {
       textBox1.Text = this._form.GetItemValue();
    }
