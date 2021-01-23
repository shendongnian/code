    protected void btSubmit_OnClick(object sender, EventArgs e)
    {
      Page.Valide();
      if (!Page.IsValid)
         return;
      var customer = new Customer();
      // init 20 properties of customer
     ....
      var bo = new CustomerBO();
      bo.Save(customer);
    }
