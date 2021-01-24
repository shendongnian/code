    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Client;
    using Microsoft.Xrm.Tooling.Connector;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public override void Run()
    {            
    	var totalDiscount = 200000;
    	using (var ctx = new OrganizationServiceContext(svc))
    	{
    		var q = from l in ctx.CreateQuery("opportunityproduct")
    				where l.GetAttributeValue<EntityReference>("opportunityid").Id.Equals(new Guid("D80E0283-5BF2-E311-945F-6C3BE5A8DD64"))                             
    				select l;
    		var lines = q.ToList();
    
    		var total = lines.Sum(l => getLineTotal(l));
    		var discountPercent = totalDiscount / total;
    		lines.ForEach(l =>
    		{
    			var discount = discountPercent * getLineTotal(l);
    			l["manualdiscountamount"] = new Money(discount);
    			ctx.UpdateObject(l);
    		});
    		ctx.SaveChanges();
    	}
    }
    
    private decimal getLineTotal(Entity line) => 
    	line.GetAttributeValue<Money>("priceperunit").Value * line.GetAttributeValue<decimal>("quantity");
       
