            private void Form1_Load(object sender, EventArgs e)
            {
                Object tag;
                SelectBox("test", new String[] { "One", "Two", "Three" }, new String[] {"one value", "Two value", "three value" }, out tag);
                MessageBox.Show(tag.ToString());
            }
    
            public static DialogResult SelectBox(string title, string[] btnArray, string[] btnValueArray, out Object tagValue)
            {
                TestForm form = new TestForm();
    
                Button[] buttonArray;
                buttonArray = new Button[5];
    
                form.Text = title;
    
                for (int i = 0; i < btnArray.Length; i++)
                {
                    buttonArray[i] = new Button();
                    buttonArray[i].Text = btnArray[i];
                    buttonArray[i].Tag = new int();
                    buttonArray[i].Tag = btnValueArray[i];
    
                    buttonArray[i].TabStop = false;
                    buttonArray[i].Location = new System.Drawing.Point(0, i * 40);
                    buttonArray[i].Size = new System.Drawing.Size(240, 40);
                    // subscribe to button click event..
                    // the handler is in TestForm
                    buttonArray[i].Click += form.HandleOnButtonClick;
                }
    
                form.ClientSize = new Size(240, 268);
                form.Controls.AddRange(new Control[] { buttonArray[0], buttonArray[1], buttonArray[2] });
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterScreen;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
    
                DialogResult dialogResult = form.ShowDialog();
                // set the out args value
                tagValue = form.Tag;
    
                return dialogResult;
            }
