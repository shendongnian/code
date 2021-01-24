        if (txtName.Text == "" && txtSCNnumber.Text == "") 
            {
                MessageBox.Show("Please complete all fields");   
             
                txtName.Focus();  
               
            }
            else if (txtSCNnumber.Text.Length != 9)
            {
                MessageBox.Show("You have entered an invalid SCN number"); 
                txtSCNnumber.Focus(); 
            }
            else
            {
                
                CourseDetails.Name = txtName.Text;  
                CourseDetails.SCNnumber = txtSCNnumber.Text; 
            }
