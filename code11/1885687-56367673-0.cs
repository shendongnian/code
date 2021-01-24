c#
private void btnDel_Click(object sender, EventArgs e)   {
        DialogResult result = MessageBox.Show("Sales system ", "Are you sure to delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
        {
            string photo = txtPhoto.ToString();
            var edit = db.tblPersons.Where(c => c.PhotoNo == photo || c.ReceiptNo == photo).FirstOrDefault();
            if(edit != null)
            {
              db.tblPersons.Remove(edit);
              db.SaveChanges();
              MessageBox.Show("Info deleted");
            }
        }
    }
