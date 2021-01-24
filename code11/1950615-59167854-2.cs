    if (cust.TryGetValue(tbCUSTOMERID.Text, out CustItem item))
	{
		MessageBox.Show("Customer found!");
        tbCUSTOMERID.Text = item.GScID;
        tbCUSTOMERNAME.Text = item.GSname;
        tbCITY.Text = item.GSlocation;
        tbEMAIL.Text = item.GSemail;
	}
	else
	{
		MessageBox.Show("Customer doesn't exist");
	}
	
	
