		protected void rcbInvoiceNumber_DataBound(object sender, EventArgs e)
		{
			//set the initial footer label
			((Literal)rcbInvoiceNumber.Footer.FindControl("RadComboItemsCount")).Text = Convert.ToString(rcbInvoiceNumber.Items.Count);
		}
		protected void rcbInvoiceNumber_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			var invs = new VInvoicesCasesTotalCollection()
				.Load();
			rcbInvoiceNumber.DataSource = invs.ToDataTable();
			rcbInvoiceNumber.DataBind();
		}
		protected void rcbInvoiceNumber_ItemDataBound(object sender, RadComboBoxItemEventArgs e)
		{
			//set the Text and Value property of every item
			//here you can set any other properties like Enabled, ToolTip, Visible, etc.
			e.Item.Text = ((DataRowView)e.Item.DataItem)["InvoiceNumber"].ToString();
			e.Item.Value = ((DataRowView)e.Item.DataItem)["InvoiceID"].ToString();
		}
