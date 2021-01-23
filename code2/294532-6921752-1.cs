    protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chall = (CheckBox)sender;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chSelect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                if (chSelect != null)
                {
                    chSelect.Checked = chall.Checked;
                }
            }
        }
        protected void chkSelect_CheckedChange(object sender, EventArgs e)
        {
            int i=0;
            CheckBox chkAll = (CheckBox)GridView1.HeaderRow.FindControl("chkAll");
            for ( i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkSelect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                if(chkSelect!=null && !chkSelect.Checked  )
                    if (chkAll != null)
                    {
                        chkAll.Checked = false;
                    }
                break;
            }
            if (GridView1.Rows.Count == i && chkAll != null)
            {
                chkAll.Checked = true;
            }
    
        }
        protected void ddlPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlpaymode = (DropDownList)sender;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lblpaymode = (Label)GridView1.Rows[i].FindControl("lblPayAmt_Mode");
                CheckBox chpaymode = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                if (chpaymode.Checked)
                {
                    lblpaymode.Text = ddlpaymode.SelectedItem.Text;
                }
            }
        }
        protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddlBank = (DropDownList)sender;
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox cselect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                Label lblBankName = (Label)GridView1.Rows[i].FindControl("LblBank");
                if (cselect.Checked)
                {
                    lblBankName.Text = ddlBank.SelectedItem.Text;
                }
    
            }
        }
        protected void btnaddbpc_Click(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(txtChequeNo.Text);
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkselect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                Label lblcheckno = (Label)GridView1.Rows[i].FindControl("LblCheque");
                
               
                if (chkselect.Checked)
                {
                   
                    lblcheckno.Text = Convert.ToString(temp);
                    temp++; 
                }
                
            }
        }
        protected void dtnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                CheckBox chkselect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                Label lblcheckno = (Label)GridView1.Rows[i].FindControl("LblCheque");
    
    
                if (chkselect.Checked)
                {
                    lblcheckno.Text = "";
                }
    
            }
        }
        protected void btnAddCDate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lblchqdate = (Label)GridView1.Rows[i].FindControl("LblCheque_Date");
                CheckBox chkselect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                if (chkselect.Checked)
                {
                    lblchqdate.Text = TxtChequeDate.Text;
                }
            }
        }
        protected void btnRemovecDate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Label lblchqdate = (Label)GridView1.Rows[i].FindControl("LblCheque_Date");
                CheckBox chkselect = (CheckBox)GridView1.Rows[i].FindControl("ChkSelect");
                if (chkselect.Checked)
                {
                    lblchqdate.Text = "";
                }
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Modify")
            {
                string ID = e.CommandArgument.ToString();
                //Response.Redirect("Admin_Update_BinryPayment.aspx?id="+ID+"&FromDate='"+ txtfromdate.Text +"'&ToDate='"+txttilldate.Text+"'");
                int Index = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).RowIndex;
                CheckBox chksec = (CheckBox)GridView1.Rows[Index].FindControl("ChkSelect");
                Label lblANo = (Label)GridView1.Rows[Index].FindControl("Label2");
                Label lbAName = (Label)GridView1.Rows[Index].FindControl("Label3");
                Label lbACName = (Label)GridView1.Rows[Index].FindControl("Label3");
                Label lbacNo = (Label)GridView1.Rows[Index].FindControl("lblBankAccountNo");
                Label lbBankName = (Label)GridView1.Rows[Index].FindControl("LblBank");
                Label lbchqNo = (Label)GridView1.Rows[Index].FindControl("LblCheque");
                Label lbchqDate = (Label)GridView1.Rows[Index].FindControl("LblCheque_Date");
                Label lblChqAmt = (Label)GridView1.Rows[Index].FindControl("Label23");
                if (chksec.Checked)
                {
                    txtABNo.Text = GridView1.Rows[Index].Cells[3].Text;
         
