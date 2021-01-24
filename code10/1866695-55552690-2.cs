    private void btnClose_Click(object sender, EventArgs e)
    {
        student.Id = txtStudentID.Text; // Only id the Id is editable.
        student.Mark = txtMark.Text;
        Close();
    }
