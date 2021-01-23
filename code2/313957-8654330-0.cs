        CommonFunction objComm = new CommonFunction();
        Hashtable objHash = new Hashtable();
        //Hashtable htParam = new Hashtable();
        objHash.Clear();
        string str = ddlMonthlyYrs.SelectedItem.Text.ToString();
        if (str == "Select")
        {
            objHash.Add("@Cmonth", "");
        }
        else
        {
            objHash.Add("@Cmonth", str.Substring(0, 6));
        }
        if (ddlPaymentTerm.SelectedItem.Text == "Select")
        {
            objHash.Add("@PaymentTerm", "");
        }
        else
        {
            objHash.Add("@PaymentTerm", ddlPaymentTerm.SelectedValue.ToString());
        }
        if (ddlPayMode.SelectedItem.Text == "Select")
        {
            objHash.Add("@PaymentMode", "");
        }
        else
        {
            objHash.Add("@PaymentMode", ddlPayMode.SelectedValue);
        }
       
       
       
        objHash.Add("@PolicyNo", txtPolicyNo.Text);
        
        objHash.Add("@AgentCode", txtAgnCode.Text);
        objHash.Add("@AgentName", txtAgnName.Text);
        DataSet objDS = objComm.GetDataSetForPrcDBConn("Prc_GetIncBasedataRp", objHash, "Commssion");
        BasicComm.CommonFunction objCom = new BasicComm.CommonFunction();
        Response.Clear();
        //Response.Charset=”";
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);
        System.Web.UI.WebControls.DataGrid dg = new System.Web.UI.WebControls.DataGrid();
        dg.DataSource = objDS.Tables[0];
        dg.DataBind();
        dg.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
