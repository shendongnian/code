    public partial class Form1 : Form
    {        
        public Form1()
        {
            InitializeComponent();                        
        }        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
                return; 
            // Lines corresponding to the first and last characters:
            int firstLine = richTextBox1.GetLineFromCharIndex(0); 
            int lastLine = richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length);
            // Get array of lines:
            List<string> lines = new List<string>();
            for (int i = firstLine; i <= lastLine; i++)
            {
                int firstIndexFromLine = richTextBox1.GetFirstCharIndexFromLine(i);
                int firstIndexFromNextLine = richTextBox1.GetFirstCharIndexFromLine(i + 1);
                if (firstIndexFromNextLine == -1)
                {
                    // Get character index of last character in this line:
                    Point pt = new Point(richTextBox1.ClientRectangle.Width, richTextBox1.GetPositionFromCharIndex(firstIndexFromLine).Y);
                    firstIndexFromNextLine = richTextBox1.GetCharIndexFromPosition(pt);
                    firstIndexFromNextLine += 1;
                }
                lines.Add(richTextBox1.Text.Substring(firstIndexFromLine, firstIndexFromNextLine - firstIndexFromLine));
            }
            
            // Print to richTextBox2 while debugging:
            richTextBox2.Text = "";
            foreach (string line in lines)
            {
                richTextBox2.AppendText(">> " + line + Environment.NewLine);
            }                        
        }
    }
