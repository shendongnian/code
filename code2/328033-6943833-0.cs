    foreach(var control1 in groupBox2.Controls)         
    {             
        if (control is Panel)
        {
            foreach (var control2 in control1.Controls)             
            {
                if (control2 is RadioButton)
                {
                    if (!(control2 as RadioButton).Checked)                
                    {                     
                         MessageBox.Show(control2.Text);
                    }
                }
            }
        }
    }            
