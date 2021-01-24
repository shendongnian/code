    protected void btnUpdate_Click(object sender, EventArgs e)
    {
      try
      {
        int buyerId = Convert.ToInt32(Session["Buyer"].ToString());
        Buyer buyer = aDal.getBuyerByID(buyerId);
          
    	  if(buyer!=null) 
    	  {
    	    buyer.BuyerTitle = txtTitle.Text;
            buyer.BuyerFName = txtFName.Text;
            buyer.BuyerLName = txtLName.Text;
            buyer.BuyerEmail = txtEmail.Text;
            buyer.BuyerPassword = txtPassword.Text;
            buyer.BuyerTelNo = txtTelNo.Text;
            buyer.BuyerPostcode = txtPostcode.Text;
            buyer.BuyerPriceRange = Convert.ToSingle(txtPrice.Text);
            buyer.BuyerType = txtType.Text;
    		
    		aDal.editBuyerByID(buyer);
          }
    	  
    	  string editBuyerScript = "alert(\"Your details have been updated\");";
    	  ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", editBuyerScript, true);
      }
      catch
      {
        string invalidScript = "alert(\"All fields must be filled correctly\");";
    	ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", invalidScript, true);
      }
    }
