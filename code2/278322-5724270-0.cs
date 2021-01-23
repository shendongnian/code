    List<customer> custList = GetAllCustomers();
                dataGridView1.Rows.Clear();
     
                foreach (Customer cust in custList)
                {
                    //First add the row, cos this is how it works! Dont know why!
                    DataGridViewRow R = dataGridView1.Rows[dataGridView1.Rows.Add()];
                    //Then edit it
                    R.Cells["Name"].Value = cust.Name;
                    R.Cells["Address"].Value = cust.Address;
                    R.Cells["Phone"].Value = cust.PhoneNo;
                    //Customer Id is invisible but still usable, like,
                    //when double clicked to show full details
                    R.Tag = cust.IntCustomerId;
                }
