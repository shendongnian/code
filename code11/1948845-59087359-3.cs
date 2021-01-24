     using System.Linq;
     ...
     private void text_Opening(object sender, CancelEventArgs e) { 
       // Here, in the FirstOrDefault, we can put any condition
       Customer findCustomer = myCustomer
         .FirstOrDefault(customer => customer.CustId == txtCustID.Text);      
       if (findCustomer != null) {
         // Customer found, (s)he is findCustomer
         MessageBox.Show("Customer found");
         // ...
       }
       else 
         MessageBox.Show("Customer not found"); 
     }
