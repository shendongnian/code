    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.AddRange(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
    
        }
    
        //ADD button
        private void button1_Click(object sender, EventArgs e)
        {
            MoveItem(listBox1, listBox2);
        }
    
        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            MoveItem(listBox1, listBox2);
        }
    
    
        //REMOVE button
        private void button2_Click(object sender, EventArgs e)
        {
            MoveItem(listBox2, listBox1);
        }
    
        private void listBox2_DoubleClick(object sender, EventArgs e)
        {
            MoveItem(listBox2, listBox1);
        }
    
        /// <summary>
        /// Moves item from one listbox to another
        /// </summary>
        /// <param name="listBoxFrom">Origin listbox</param>
        /// <param name="listBoxTo">Destination listbox</param>
        private void MoveItem(ListBox listBoxFrom, ListBox listBoxTo)
        {
            if (listBoxFrom.SelectedItems.Count == 1)
            {
                listBoxTo.Items.Add(listBoxFrom.SelectedItem);
                listBoxFrom.Items.Remove(listBoxFrom.SelectedItem);
            }
        }
    } 
