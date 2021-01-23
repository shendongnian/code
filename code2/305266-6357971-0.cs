    if (TextBox1.Text.Length > 0)
    {
       DR["CustomerID"] = Convert.ToInt32(TextBox1.Text); ;
    }
    else
    {
      DR["CustomerID"] = null;  
    }
