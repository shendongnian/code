        private void allBlackLabels()
        {    
            foreach (Control control in this.Controls)            
            {
                if (control is Label && control.Name != "label4")
                {
                    (control as Label).Forecolor = Color.Black;
                }
            }
        }
