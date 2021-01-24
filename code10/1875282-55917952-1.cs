    foreach (GridViewRow row in grdDisplayCMMData.Rows)
    {
          if (((Checkbox)row.FindControl("chkApprRejCMM")).Checked)
          {
          Label SAPID_CMM = (Label)row.FindControl("lblSAP_ID_CMM");
    
          ObjIPColoFields.Unique_Id = Id;
          ObjIPColoFields.UMS_GRP_BY_ID = intCurrentGrpId;
          ObjIPColoFields.UMS_GRP_BY_NAME = strCurrentGrp;
          ObjIPColoFields.UMS_GRP_TO_ID = UMSGroupDetails[1].GroupID;
          ObjIPColoFields.UMS_GRP_TO_NAME = UMSGroupDetails[1].GroupName;
          ObjIPColoFields.FCA_STATUS = "1";
          ObjIPColoFields.LAST_UPDATED_BY = lblUserName.Text;
          strDate = DateTime.Now.ToString();                                                    
    
          strApprove = CommonDB.Approve_IPCOLO_CMMLevel(ObjIPColoFields);
    
          if (ObjIPColoFields.Unique_Id != null || ObjIPColoFields.Unique_Id != 0)
          {
                strMailContent = Get_Email_Content(ObjIPColoFields.LAST_UPDATED_BY, SAPID_CMM.Text, strIPCOLO_CMM, Convert.ToString(Id), strDate, "Approved");
                SendEmail(lblUserName.Text, strMailContent, strIPCOLO_CMM);
          }
          }
     }
