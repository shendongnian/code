    //Add tag
    String tag = "";
    
            TextBox txtBox3 = new TextBox();
            txtBox3 = new TextBox();
            txtBox3.Location = new Point(313, position);
            txtBox3.Visible = true;
            txtBox3.Name = "txt_QTY" + qtyTextbox;
            txtBox3.TextChanged += txtBox3_TextChanged;
            txtBox3.KeyPress += txtBox3_KeyPress;
    
    tag = "txt_QTY" + qtyTextbox;
    
            qtyTextbox++;
    
            TextBox txtBox4 = new TextBox();
            txtBox4 = new TextBox();
            txtBox4.Location = new Point(447, position);
            txtBox4.Visible = true;
            txtBox4.Name = "txt_Price" + priceTextbox;
            txtBox4.TextChanged += txtBox4_TextChanged;
            txtBox4.KeyPress += txtBox4_KeyPress;
    
    tag += "," + "txt_Price" + priceTextbox;
    
            priceTextbox++;
    
    
            TextBox txtBox5 = new TextBox();
            txtBox5 = new TextBox();
            txtBox5.Location = new Point(556, position);
            txtBox5.Visible = true;
            txtBox5.Name = "txt_Total" + totalTextbox;
            totalTextbox++;
    
    tag += "," + "txt_Total" + totalTextbox;
    
    
    //Set same tag into three 3 textbox
          txtBox3.Tag = txtBox4.Tag =  txtBox5.Tag = tag;
    
    Add a parse function:
    
     private TextBox[] getTextBoxFromTag(String Tag)
        {
    	TextBox [] arrTextBox = new [3] TextBox();
    	String arrTag[] = Tag.Split(",");
    	//Harcode 
    	arrTextBox[0] = GetControlByName(this, arrTag[0]);
    	arrTextBox[1] = GetControlByName(this, arrTag[1]);
    	arrTextBox[2] = GetControlByName(this, arrTag[2]);
    	return arrTextBox;
        }
    
    public Control GetControlByName(Control ParentCntl, string NameToSearch)
        {
            if (ParentCntl.Name == NameToSearch)
                return ParentCntl;
    
            foreach (Control ChildCntl in ParentCntl.Controls)
            {
                Control ResultCntl = GetControlByName(ChildCntl, NameToSearch);
                if (ResultCntl != null)
                    return ResultCntl;
            }
            return null;
    }
    
    void updateTotal(object sender){
    	String tag = ((TextBox)sender).Tag;
    	TextBox [] txt = getTextBoxFromTag(tag);
    	txt[2].Text = Convert.ToInt32(txt[0].Text) * Convert.ToInt32(txt[1].Text);
    }
    private void txt_QTY_TextChanged(object sender, EventArgs e)
    {
    	updateTotal(sender);
    }
    
    private void txt_Price_TextChanged(object sender, EventArgs e)
    {
    	updateTotal(sender);
    }
