     private void text_Opening(object sender, CancelEventArgs e) { 
       // We prepare artificial Customer to be found 
       Customer customerToFind = new Customer() {
         CustId == txtCustID.Text,  
       };
       int index = Array.BinarySearch(myCustomer, customerToFind);
       if (index >= 0) {
         Customer findCustomer = myCustomer[index];
         MessageBox.Show("Customer found");
         // ...
       }
       else
         MessageBox.Show("Customer not found"); 
     }
     
