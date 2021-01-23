    private void pictureBox1_Click(object sender, EventArgs e)
        {
            form2 box = new form2();
            using (box)
            {
                box.ShowDialog();
                if (box.DialogResult == DialogResult.OK)
                {
                    refreshData();
                }
                box.Dispose();
            }
        }
        private void refreshData()
    {
    ADODB.Recordset rs = new ADODB.Recordset();
               ADODB.Connection adoCon = new ADODB.Connection();
               adoCon.Open("put Connection String Here");
               rs.Open("Put Select query Here",adoCon,ADODB.CursorTypeEnum.adOpenStatic,ADODB.LockTypeEnum.adLockOptimistic);
               DataSet myDS = new DataSet();
               OleDbDataAdapter da = new OleDbDataAdapter();
               da.Fill(myDS, rs,"MyTable");
               chkList1.DataSource = null;
               chkList1.DataSource = myDS.Tables[0];
               chkList1.DisplayMember = "Put Field to Display in CheckList here";
    }
