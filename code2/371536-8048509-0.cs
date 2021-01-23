    private void textBox1_TextChanged(object sender, EventArgs e)
            {
                Size size = TextRenderer.MeasureText(textBox1.Text, textBox1.Font);
                textBox1.Width = size.Width;
                textBox1.Height = size.Height;
            }
