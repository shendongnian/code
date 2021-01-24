                Control[] labels = this.Controls.Cast<Control>().Where(x => x.GetType() == typeof(Label)).ToArray() ;
                for(int i = labels.Length - 1; i >= 0; i--)
                {
                    Label label = (Label)labels[i];
                    TextBox newBox = new TextBox();
                    newBox.Left = label.Left;
                    newBox.Top = label.Top;
                    newBox.Width = label.Width;
                    newBox.Height = label.Height + 10;
                    newBox.Text = label.Text;
                    label.Parent.Controls.Add(newBox);
                    label.Parent.Controls.Remove(label);
                }
