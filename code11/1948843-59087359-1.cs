     using System.Linq;
     ...
     private void text_Opening(object sender, CancelEventArgs e) { 
       Customer findCustomer = myCustomer
         .FirstOrDefault(item => item.CustId == txtCustID.Text);      
       if (findCustomer != null) {
         // Customer found, (s)he is findCustomer
         MessageBox.Show("Customer found");
         // ...
       }
       else 
         MessageBox.Show("Customer not found"); 
     }
