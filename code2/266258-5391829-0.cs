    public partial class Form1 : Form
    {
      public Form1()
      {
         InitializeComponent();
         ReadFile();
      }
      private void ReadFile()
      {
         // Assumes there are 3 columns (and 3 input values from the user)
         string[] lines_in_file = File.ReadAllLines(@"C:\Temp\FixedWidth.txt");
         foreach (string line in lines_in_file)
         {
            int offset = 0;
            int column_width = (int)ColumnWidth1NumericUpDown.Value;
            // Set the color for the first column
            richTextBox1.SelectionColor = Color.Khaki;
            richTextBox1.AppendText(line.Substring(offset, column_width));
            offset += column_width;
            column_width = (int)ColumnWidth2NumericUpDown.Value;
            // Set the color for the second column
            richTextBox1.SelectionColor = Color.HotPink;
            richTextBox1.AppendText(line.Substring(offset, column_width));
            offset += column_width;
            column_width = (int)ColumnWidth3NumericUpDown.Value;
            // Make sure we dont try to substring incorrectly
            column_width = (line.Length - offset < column_width) ?
                line.Length - offset : column_width; 
            // Set the color for the third column
            richTextBox1.SelectionColor = Color.MediumSeaGreen;
            richTextBox1.AppendText(line.Substring(offset, column_width));
            // Add newline
            richTextBox1.AppendText(Environment.NewLine);
         }
      }
    }
