    private void expired()
    {
    DateTime expired = DateTime.Parse(Convert.ToDateTime(datetimepicker1.Text).ToString());
    DateTime compare = DateTime.Parse(Convert.ToDateTime(datetimepicker2.Text).ToString());
    
    if(expired < compare)
    {
    MessageBox.Show("This product is expired!");
    }
    else
    }
    MessageBox.Show("This product is not expired");
    {
    }
