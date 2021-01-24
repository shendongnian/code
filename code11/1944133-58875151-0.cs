    try{
      double x = Convert.ToDecimal(txtPrice.Text)
     }
     catch(Exeption e){
     MessageBox.Show("Price must be a positive number", "Error!", 
     MessageBoxButtons.OK,MessageBoxIcon.Error);
     }
