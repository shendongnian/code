    public Form1()
    {
        InitializeComponent();
        int[,] my_table = new int[9, 9] {
                    { 8,2,3,4,5,9,1,6,7},
                    { 6,9,7,8,1,2,5,6,4},
                    { 5,1,4,6,7,3,2,9,8},
                    { 7,4,1,3,9,6,8,2,5},
                    { 3,6,5,1,2,8,7,4,9},
                    { 2,8,9,5,4,7,6,1,3},
                    { 1,5,2,7,3,4,9,8,6},
                    { 9,3,8,2,6,5,4,7,1},
                    { 4,7,6,9,8,1,3,5,2},
                };
        dataGridView1.DataSource = FillDTB(my_table) ;
        dataGridView1.Refresh();
        for(int ii=0; ii<9; ii++)
        {
            for (int jj = 0; jj < 9; jj++)
            {
                richTextBox1.Text += my_table[ii, jj];
                if (jj != 8)
                {
                    richTextBox1.Text += ".";
                }
            }
            richTextBox1.Text += Environment.NewLine;
        }
         dataGridView1.Invalidate();
    }
    private DataTable GetDTB(int count)
    {
        DataTable tb = new DataTable();
        for (int i = 1; i < count + 1; i++)
        {
            tb.Columns.Add();
        }
        return tb;
    }
    private DataTable FillDTB(int[,] matrix, int count = 9)
    {
        
        DataTable dtb = GetDTB(count);
        for (int ii = 0; ii < count; ii++)
        {
            DataRow my_line;
            my_line = dtb.NewRow();
            for (int jj = 0; jj < count; jj++)
            {
                my_line[jj] = matrix[ii, jj];
            }
            dtb.Rows.Add(my_line);
        }
        return dtb;
     }//*/
