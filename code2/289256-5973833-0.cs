        double c ;
    try{
     c= double.Parse(boxf.Text);
    }catch{
    MessageBox.Show("Error!Invalid Data");
    return;
    }
        
        if (boxc.Text.Trim().length==0)
                        boxc.Text =( (c * 9 /5) +32).ToString();
