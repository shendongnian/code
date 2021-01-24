    public partial class Form1 : Form
    {
        public static List<string> studentInfo = new List<string>();
        // ... other code ...
        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            addRecord frmAddRecord = new addRecord();
            if (frmAddRecord.ShowDialog() == DialogResult.OK)
            {
                studentInfo.Add(frmAddRecord.Student);
                studentInfo.Add(frmAddRecord.Score);
                lstMarks.Items.Add(frmAddRecord.Student + " : " + frmAddRecord.Score);
            }
        }
    }
