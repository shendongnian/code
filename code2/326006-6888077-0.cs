    protected void btnBulkAssign_Click(object sender, EventArgs e)
    {
      for (int i = 0, i < grdFranchise.Rows.Count, i++)
      {
         Label lblNetPayments = (Label)grdFranchise.Rows[i].FindControl("lblNetPayments");
         Label checkMyPaymentStatus = (Label)grdFranchise.Rows[i].FindControl("checkMyPaymentStatus ");
         TextBox txtMypayment = (TextBox)grdFranchise.Rows[i].FindControl("txtMypayment");
    
         lblNetPayments.Visible = false;
         checkMyPaymentStatus.Visible = true;
         txtMypayment.Visible = true;
      }
    }
