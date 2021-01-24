public partial class Form1 : Form
    {
        private HashSet<TextBox> validatedInputs = new HashSet<TextBox>();
        private int inputsCount;
        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            foreach (var tb in groupBox1.Controls.OfType<TextBox>())
            {
                tb.Validating += allTextBoxs_ValidatingAndEditing;
                tb.TextChanged += allTextBoxs_ValidatingAndEditing;
                inputsCount++;
            }
        }
        private void allTextBoxs_ValidatingAndEditing(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                if (!int.TryParse(tb.Text, out int value) || value < 0 || value > 100)
                {
                    if (e is CancelEventArgs ce)
                        ce.Cancel = true;
                    errorProvider1.SetError(tb, "Value must be in range [0..100]");
                    validatedInputs.Remove(tb);
                }
                else
                {
                    errorProvider1.SetError(tb, null);
                    validatedInputs.Add(tb);
                }
                setAddButtonEnabled();
            }
        }
        private void setAddButtonEnabled() => button1.Enabled = validatedInputs.Count == inputsCount;
    }
[![FormValidation][1]][1]
Be careful, this implementation is so restrictive that user even cannot close a form until he types a right value :)
  [1]: https://i.stack.imgur.com/X7TGm.png
