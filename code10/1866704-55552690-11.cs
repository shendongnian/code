    private void BtnEditMark_Click(object sender, EventArgs e)
    {
        if (lstMarks.SelectedIndex == -1) {
            MessageBox.Show("please select a student");
        } else {
            var student = (Student)lstMarks.SelectedItem;
            var myEditRecordForm = new editMark(student);
            Hide();
            myEditRecordForm.ShowDialog();
            Show(); // Doing this here prevents you from having the edit form knowing about Form1.
            // To display the changes.
            lstMarks.Items[lstMarks.SelectedIndex] = student;
        }
    }
