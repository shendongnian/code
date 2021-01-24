    dataGridView1.Rows.Add(txt_name.Text, txt_grade.Text);
    private void btn_calculate_Click(object sender, EventArgs e)
    {
        int passingMarks = 50;
 
        int[] columnData = (from DataGridViewRow row in dataGridView1.Rows
                            where row.Cells[1].FormattedValue.ToString()!= string.Empty
                            select Convert.ToInt32(row.Cells[1].FormattedValue)).ToArray();
        lbl_average.Text = "Average grade is: " + columnData.Average().ToString();
        lbl_highest.Text = "Highest grade is: " + columnData.Max().ToString();
        var passingStudents = columnData.AsQueryable().Where(g=>g >= passingMarks).Count();
        var passingRate = ((double)passingStudents / columnData.Length) * 100;
        lbl_passrate.Text = String.Format("Pass Rate = {0}%", passingRate);
    }
