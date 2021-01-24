            o[next] = new TEST { name = textBox1.Text };
            next++;
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(o[int.Parse(textBox2.Text)].name);
        }
