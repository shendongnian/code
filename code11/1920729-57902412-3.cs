    private void BntAdd_Click(object sender, EventArgs e) 
    {
        //Get the value from the imput fields
        c.Nome = txtBoxName.Text;
        c.Cognome = txtBoxSurname.Text;
        c.Telefono1= txtBoxPhone1.Text;
        c.Telefono = txtBoxPhone.Text;
        c.Email = txtBoxEmail.Text;
    
    	try
    	{
    		//Inserting Data into Database uing the method we created is previous episode
    		bool success = c.Insert(c);
    		if (success == true)
    		{
    			//Successfully Inserted
    			MessageBox.Show("New contact added!");
    			//Call the clear Method Here
    			Clear();
    		}
    		else
    		{
    			//Failed to add Contact
    			MessageBox.Show("ERROR!)");
    		}
    		//load Data on Data GRidview
    		DataTable dt = c.Select();
    		dgvRubrica.DataSource = dt;
    	}
    	catch(Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    }
