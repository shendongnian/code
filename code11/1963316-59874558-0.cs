    public ActionResult BankLinkApprove(UserInfo model, string btnApprove, FormCollection collection, string Remarks){
            
            if (Remarks.Equals("Others")){
            userInfo.Remarks = collection["OthersRemarks"].ToString();
            }
            else{
            userInfo.Remarks = info.Remarks;
            }
    }
