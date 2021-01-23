    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int flage = 1;
        private void button1_Click(object sender, EventArgs e)
        {
            flage = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    DataGridViewRow currentRow = dataGridView1.SelectedRows[0];
                    TreeNode node1 = new TreeNode(currentRow.Cells[1].Value.ToString());
                    TreeNode node2 = new TreeNode(currentRow.Cells[2].Value.ToString());
                    TreeNode node3 = new TreeNode(currentRow.Cells[3].Value.ToString());
                    TreeNode[] TreeArray = new TreeNode[] { node1,node2, node3 };
                    TreeNode finalnode = new TreeNode(currentRow.Cells[0].Value.ToString(), TreeArray);
                    treeView1.Nodes.Add(finalnode);
                    flage = 1;
                    break;
                }
                else
                {
                    flage = 0;
                    
                }
            }
           if(flage==0)
            {
                MessageBox.Show("Row is not Selected Please select the row");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Remove( treeView1.SelectedNode);
        }
        int flage2;
        private void button3_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                    flage2 = 1;
                    break;
                }
                else
                {
                    flage2 = 0;
                }
            }
            if (flage2 == 0)
            {
                MessageBox.Show("Row is not selected Please select the row");
            }
        }
    }
