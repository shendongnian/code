    protected void BtnAdd_Click(object sender, EventArgs e)
    {
        Student obj = new Student();
        string studentid = TxtStdId.Text;
        decimal collectionamount = 0.0m;
        if (txtCollectionAmount.Text !=null)
        {
           bool canConvert = decimal.TryParse(txtCollectionAmount.Text, out collectionAmount);
           if (!canConvert)
           {
               // ... obviously the text in the textbox was invalid for some reason...
               // put the handler for the invalid data here.
           }
        }
        DateTime collectiondate = Convert.ToDateTime(txtCollectionDate.Text);           
        lblResult.Text=obj.FeesCollection(studentid, collectionamount, collectiondate);
    
    }
