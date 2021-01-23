                Form newForm = new Form();
               
                CustomLabel newLabel = new CustomLabel();
                newForm.Controls.Add(newLabel);
    
                newLabel.BackColor = Color.Black;
                newLabel.Font = new System.Drawing.Font("Microsoft Arial", 18F,
                FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                newLabel.ForeColor = Color.Crimson;
                newLabel.Text = "Some text on a topmost transparent form window";
    
                newForm.Show();
                newForm.TopMost = true;
    
                newLabel.AutoSize = true;
                newLabel.Location = new Point(230, 375);
