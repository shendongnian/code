    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;
    using Microsoft.Xrm.Tooling.Connector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class InvoicesModel
    {
    	public Guid? InvoiceID { get; set; }
    	public EntityReference ClientName { get; set; }
    	public string InvoiceNumber { get; set; }
    	public string Name { get; set; }
    	public bool? PaymentReceived { get; set; }
    	public decimal? Commission { get; set; }
    	public decimal? AdminFee { get; set; }
    	public decimal? DiscountAmount { get; set; }
    }
    
    public List<InvoicesModel> RetrieveInvoiceModels(string connectionString)
    {
    	var svc = new CrmServiceClient(connectionString);
    
    	var query = new QueryExpression
    	{
    		EntityName = "invoice",                
    		ColumnSet = new ColumnSet("invoiceid", "customerid", "invoicenumber", "name", "discountamount"),
    		TopCount = 10
    		///Invalid column names: "paymentreceived", "commission", "adminfee",
    	};
    
    	var invoices = svc.RetrieveMultiple(query).Entities.ToList();
    
    	var invoiceModels = invoices.Select(i =>
    		new InvoicesModel
    		{
    			InvoiceID = i.GetAttributeValue<Guid>("invoiceid"),
    			ClientName = i.GetAttributeValue<EntityReference>("customerid"),
    			InvoiceNumber = i.GetAttributeValue<string>("invoicenumber"),
    			Name = i.GetAttributeValue<string>("name"),
    			DiscountAmount = i.GetAttributeValue<Money>("new_discountamount")?.Value
    			
    			///for when columnn names are fixed:
    			//PaymentReceived = i.GetAttributeValue<bool>("new_paymentreceived")
    			//AdminFee = i.GetAttributeValue<Money>("new_adminfee")?.Value,
    			//Commission = i.GetAttributeValue<Money>("new_commission")?.Value,
    		})
    		.ToList();
    	return invoiceModels;
    }
