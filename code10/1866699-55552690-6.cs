    private void btnClose_Click(object sender, EventArgs e)
    {
        _student.Id = txtStudentID.Text; // Only id the Id is editable.
        _student.Mark = txtMark.Text;
        Close();
    }
