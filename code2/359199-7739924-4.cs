     foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.AllTextBoxes_MouseClick);
                    }
                }
