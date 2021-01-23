     public void GetAllControl(Control parent)
            {
                //Dosomething with parent like setting text or blah blah blah
    
                foreach (Control item in parent.Controls)
                {
                    GetAllControl(parent);
                }
            }
