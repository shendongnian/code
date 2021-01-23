     private List<Student> studentList = new List<Student>();
     private void listView1_DoubleClick(object sender, EventArgs e) {
            ListView.SelectedListViewItemCollection selectedItems = listView1.SelectedItems;
            if (selectedItems != null && selectedItems.Count > 0) {
                ListViewItem item = selectedItems[0];
                Form2 form = new Form2(item.Text);
                form.Owner = this;
                form.ShowDialog();
                // Now get the values from the form.
                Student updateStudent = studentList.Find(o => o.Id == form.Student.Id);
                if (updateStudent != null) {
                    updateStudent.Id = form.Student.Id;
                    // Update the rest of the members.
                }
                // Re-populate your list using the updated student list.
            }
        }
