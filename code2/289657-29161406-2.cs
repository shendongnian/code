      public class InputBox
            {
                public static DialogResult Show(string title, string promptText, ref string value)
                {
                    return Show(title, promptText, ref value, null);
                }
    
    
    
    
    //Fuction
    
    
                public static DialogResult Show(string title, string promptText, ref string value,
                                                InputBoxValidation validation)
                {
                    Form form = new Form();
                    Label label = new Label();
                    TextBox textBox = new TextBox();
                    Button buttonOk = new Button();
                    Button buttonCancel = new Button();
    
                    form.Text = title;
                    label.Text = promptText;
                    textBox.Text = value;
    
                    buttonOk.Text = "OK";
                    buttonCancel.Text = "Cancel";
                    buttonOk.DialogResult = DialogResult.OK;
                    buttonCancel.DialogResult = DialogResult.Cancel;
    
                    label.SetBounds(9, 20, 372, 13);
                    textBox.SetBounds(12, 36, 372, 20);
                    buttonOk.SetBounds(228, 72, 75, 23);
                    buttonCancel.SetBounds(309, 72, 75, 23);
    
                    label.AutoSize = true;
                    textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
                    buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                    buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
    
                    form.ClientSize = new Size(396, 107);
                    form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
                    form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
                    form.FormBorderStyle = FormBorderStyle.FixedDialog;
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.MinimizeBox = false;
                    form.MaximizeBox = false;
                    form.AcceptButton = buttonOk;
                    form.CancelButton = buttonCancel;
                    if (validation != null)
                    {
                        form.FormClosing += delegate(object sender, FormClosingEventArgs e)
                        {
                            if (form.DialogResult == DialogResult.OK)
                            {
                                string errorText = validation(textBox.Text);
                                if (e.Cancel = (errorText != ""))
                                {
                                    MessageBox.Show(form, errorText, "Validation Error",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    textBox.Focus();
                                }
                            }
                        };
                    }
                    DialogResult dialogResult = form.ShowDialog();
                    value = textBox.Text;
                    return dialogResult;
                }
            }
            public delegate string InputBoxValidation(string errorMessage);
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    private void button_updations_Click(object sender, EventArgs e)
            {
    
                InputBoxValidation validation = delegate(string val)
                {
                    if (val == "")
                        return "Value cannot be empty.";
                    if (!(new Regex(@"^[a-zA-Z0-9_\-\.]+@[a-zA-Z0-9_\-\.]+\.[a-zA-Z]{2,}$")).IsMatch(val))
                        return "Email address is not valid.";
                    return "";
                };
    
                string value = "";
                if (InputBox.Show("Enter your email address", "Email address:", ref value, validation) == DialogResult.OK)
                {
                   
                    if (value == "thazime7@gmail.com")
                    {
                        dataGridView1.Visible = true;
                        button_delete.Visible = true;
                        button1.Visible = true;
                        button_show.Visible = true;
                        label6.Visible = true;
                        label4.Visible = true;
                        label5.Visible = true;
                        textBox_uemail.Visible = true;
                        textBox_uname.Visible = true;
                        textBox_upassword.Visible = true;
                        textBox_delete.Visible = true;
                        button_deleteTable.Visible = true;
    
                        button_updatep.Visible = true;
                        textBox_updateall.Visible = true;
                    }
                    MessageBox.Show(value);
                }
                else
                {
                    MessageBox.Show("You are not authenticated");
    
    
    
    
    
                }
            }
