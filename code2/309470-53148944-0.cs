        IList<Customer> objCustomerList = (new CustomerFacade()).GetAllSalesOrgByUserCode(SessionManager.UserCode);
        if (objCustomerList != null && objCustomerList.Count >= 0)
        {
            ddlSalesOrg.Items.Clear();
            ddlSalesOrg.DataSource = objCustomerList;
            ddlSalesOrg.DataTextField = "SalesOrganization";
            ddlSalesOrg.DataValueField = "SalesOrgCode";
            ddlSalesOrg.DataBind();
        }
    }
