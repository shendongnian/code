        int test_reg_Id = Convert.ToInt32(grdList.DataKeys[e.NewEditIndex].Values[0]);
        string query = "select * from test_reg where Id=" + test_reg_Id + "";
        query += Session["test_reg_Id"].ToString();
        dtable = con.sqlSelect(query);
        txt_id.Text = dtable.Rows[0][0].ToString();
        txtuname.Text = dtable.Rows[0][1].ToString();
        txtpass.Text = dtable.Rows[0][2].ToString();
        ddlcountry.SelectedItem.Text = dtable.Rows[0][3].ToString();
}
