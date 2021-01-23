	private HttpClient m_RestHttpClient = new HttpClient("http://localhost:17471/CustomerService/");
	var form = new HttpUrlEncodedForm();
	form.Add("CustomerCode", txtCustomerCode.Text);
	form.Add("CustomerName", txtCustomerName.Text);
	form.Add("ContactName", txtContactName.Text);
	form.Add("Country", txtCountry.Text);
	form.Add("PostalCode", txtPostalCode.Text);
	form.Add("ClassTemplate", txtClassTemplate.Text); 
	form.Add("BusinessType", cmbBusinessType.Text);
	form.Add("IsProspect", cmbIsProspect.Text);
	using (HttpResponseMessage response = m_RestHttpClient.Post("Upload", frm.CreateHttpContent()))
	{
	    response.EnsureStatusIsSuccessful();
	}
