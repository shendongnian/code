    public class TbCost {
	    public decimal Conton {get;set;}
	    public decimal ProPri {get;set;}
	    public decimal ConPri {get;set;}
    }
    
    public void CalculateCost()//this function getting called at a button onclick
	{
		try
		{
			decimal totalTonage = 0m;
			decimal totalPrice = 0m;
			decimal priceCarpiTonage = 0m;
			decimal totalFreight = 0m;
			
			IList<TbCost> tbCosts = ReadTbCosts(TB_COST.Data.Rows);
			foreach (TbCost tbCost in tbCosts)
			{
				decimal containerTonage = tbCost.Conton;
				totalTonage += tbCost.Conton;
				
				decimal price = tbCost.ProPri;
				totalPrice += price;
				priceCarpiTonage +=  Convert.ToDecimal(containerTonage) * price; 
				decimal decimalFreightPrice = tbCost.ConPri;
				decimal decimalFreightBoluContainerTonnage = decimalFreightPrice/containerTonage;
				totalFreight += decimalFreightBoluContainerTonnage;       
			}
			
			decimal productPrice = priceCarpiTonage/totalTonage;
			productPrice = (Math.Round(productPrice, 2, MidpointRounding.AwayFromZero));
			T_PROP.Text = productPrice.ToString();
			T_TOTN.Text = totalTonage.ToString();   
			totalFreight = (Math.Round(totalFreight, 2, MidpointRounding.AwayFromZero));                                  
			T_FREG.Text = totalFreight.ToString();         
		}
		catch(Exception ex)
		{
			ShowMessageBox(ex.ToString());
		}
	}
