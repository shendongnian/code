    public partial class Form1 : Form
    {
        int last_len = 0;
        bool char_to_lower = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // save last cursor position
            var select_index = textBox1.SelectionStart;
            // if text not delete - change char casing
            if (textBox1.Text.Length > last_len && select_index > 0)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(textBox1.Text.Take(select_index - 1).ToArray());
                // check SHIFT and CAPS
                if (char_to_lower || Control.IsKeyLocked(Keys.CapsLock))
                    sb.Append(textBox1.Text[select_index - 1].ToString().ToLower());
                else
                    sb.Append(textBox1.Text[select_index - 1].ToString().ToUpper());
                sb.Append(textBox1.Text.Skip(select_index).ToArray());
                // insert new text in textBox
                textBox1.Text = sb.ToString();
                // return cursor position
                textBox1.SelectionStart = select_index;
            }
            // save last length
            last_len = textBox1.Text.Length;
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Shift) char_to_lower = true;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey || e.KeyCode == Keys.Shift) char_to_lower = false;
        }
    }
