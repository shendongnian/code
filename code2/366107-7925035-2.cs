     //Create Invoices...
            List<Invoice> lst = new List<Invoice>();
            try
            {
                foreach (ListViewItem listItem in listView1.Items)
                {
                    Invoice aux = new Invoice();                    
                    aux.Product = listItem.SubItems[0].Text;
                    aux.PArtNumber = listItem.SubItems[1].Text;
                    lst.Add(aux);
                }                
                textBox1.Text += localhost.Invoice(lst.ToArray(), true);                
            }
            catch (Exception ex)
            {
                textBox1.Text = ex.ToString();
                throw;
            }
