    public Form1()
    {
        InitializeComponent();
        int[,] my_table = new int[9, 9] {
                    { 2,1,8,3,5,7,6,4,9},
                    { 5,7,3,4,9,6,8,2,1},
                    { 6,9,4,1,8,2,3,5,7},
                    { 1,6,9,5,2,8,4,7,3},
                    { 3,5,2,9,7,4,1,8,6},
                    { 4,8,7,6,1,3,2,9,5},
                    { 7,3,5,2,4,1,9,6,8},
                    { 8,2,1,7,6,9,5,3,4},
                    { 9,4,6,8,3,5,7,1,2}
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
        // dataGridView1.Invalidate();
    }
    private DataTable GetDTB(int count)
    {
        DataTable tb = new DataTable();
        for (int i = 1; i < count + 1; i++)
        {
            tb.Columns.Add("C" + i);
        }
        return tb;
    }
    private DataTable FillDTB(int[,] matrix, int count = 9)
     {
         DataTable dtb = GetDTB(count);
         for (int i = 0; i < 9; i++)
         {
             dtb.Rows.Add(GetRow(matrix, i));
         }
         return dtb;
     }//*/
    public int[] GetRow(int[,] matrix, int rowNumber)
    {
        return Enumerable.Range(0, matrix.GetLength(1))
                .Select(x => matrix[rowNumber, x])
                .ToArray();
    }
