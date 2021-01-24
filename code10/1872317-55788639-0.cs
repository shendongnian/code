                int offsetY = 5;
                int x = 0;
                int y = 0;
                int index = 1;
    
                //Start adds new panel and new label
                Panel b = new Panel();
                Label la = new Label();
    
                //Adds panel properties
                b.Controls.Add(la);
                b.Location = new Point(x, y + offsetY);
                b.Size = new Size(633, 119);
                //newhaven.Class1 cl = new newhaven.Class1();
                b.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                flowLayoutPanel1.Controls.Add(b);
                b.ResumeLayout(false);
    
    
                // Adds label properties -
                // commented the co-ordinates and using the same as that of panel
                //x = 0;
                //y = -20;
                la.Location = new Point(x, y + offsetY);
                // la.Size = new Size(60, 30);
                la.Text = "Hello";
    
                // no need to add the label separately, its inside the panel
                //flowLayoutPanel1.Controls.Add(la); 
