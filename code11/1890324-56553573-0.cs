    using (Form formA = new Form()) {
            formA.Text = "Form A";
            formA.Name = "FormA";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.Size = new System.Drawing.Size(155, 265);
            this.Text = "Run-time Controls";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            formA.Show();
           
            for (int x = 0; x <= 3; x++)
            {
                Button btn = new Button();
                btn.Location = new System.Drawing.Point(10 + (x * 5), 10 + (x * 5));
                btn.Text = "Button" + x.ToString();
                btn.Name = "Button_" + x.ToString(); 
                formA.Controls.Add(btn);
            }
        }
