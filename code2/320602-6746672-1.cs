     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                tableLayoutPanel1.RowCount = 1;
                tableLayoutPanel1.ColumnCount = 6;
                removeButton.Enabled = false;
            }
    
             private void addButton_Click(object sender, EventArgs e)
            {
                int index = tableLayoutPanel1.RowCount - 1;
                Label label = new Label();
                TextBox Value = new TextBox();
                TextBox Weight = new TextBox();
                TextBox Width = new TextBox();
                TextBox Height = new TextBox();
                TextBox Length = new TextBox();
    
                label.Dock = DockStyle.Fill;
                label.Text = (index + 1).ToString();
                label.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
    
                Value.Dock = DockStyle.Fill;
    
                Weight.Dock = DockStyle.Fill;
    
                Width.Dock = DockStyle.Fill;
    
                Height.Dock = DockStyle.Fill;
    
                Length.Dock = DockStyle.Fill;
    
                int i = 0;
                tableLayoutPanel1.Controls.Add(label, i++, index);
                tableLayoutPanel1.Controls.Add(Value, i++, index);
                tableLayoutPanel1.Controls.Add(Weight, i++, index);
                tableLayoutPanel1.Controls.Add(Width, i++, index);
                tableLayoutPanel1.Controls.Add(Height, i++, index);
                tableLayoutPanel1.Controls.Add(Length, i++, index);
    
                tableLayoutPanel1.RowCount += 1;
    
                if (tableLayoutPanel1.RowCount > 9)
                {
                    addButton.Enabled = false;
                }
    
                if (tableLayoutPanel1.RowCount > 0)
                {
                    removeButton.Enabled = true;
                }
            }
    
            private void removeButton_Click(object sender, EventArgs e)
            {
                if (tableLayoutPanel1.RowCount > 0)
                {
                    int startIndex = ((tableLayoutPanel1.RowCount - 1) * 6) - 1;
    
                    for (int i = 0; i < 6; i++)
                    {
                        tableLayoutPanel1.Controls.RemoveAt(startIndex--);
                    }
    
                    tableLayoutPanel1.RowCount -= 1;
    
                    if (tableLayoutPanel1.RowCount == 0)
                    {
                        removeButton.Enabled = false;
                    }
    
                    if (tableLayoutPanel1.RowCount <= 9)
                    {
                        addButton.Enabled = true;
                    }
                }
            }
        }
