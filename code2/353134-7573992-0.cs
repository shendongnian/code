    // Form 1
    
    private void button5_Click(object sender, EventArgs e) // Brings up the second form
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
    
    private Form1 _form;
    
    public Form4(Form1 form)
    {
       this._form = form;
    }
    
    private void Form4_Load(object sender, EventArgs e)
    {
    
       textBox1.Text = this._form.GetItemValue();
    }
