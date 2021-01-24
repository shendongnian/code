    public class TbCost {
		public decimal Conton {get;set;}
		public decimal ProPri {get;set;}
		public decimal ConPri {get;set;}
		public decimal GetPriceCarpiTonage() {
			return Conton * ProPri;
		}
		public decimal GetFreightBoluContainerTonnage() {
			return ConPri / Conton;
		}
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
				totalTonage += tbCost.Conton;				
				totalPrice += tbCost.ProPri;
				priceCarpiTonage +=  tbCost.GetPriceCarpiTonage(); 
				totalFreight += tbCost.GetFreightBoluContainerTonnage();   
			}
			
			T_PROP.Text = Round(priceCarpiTonage/totalTonage);
			T_TOTN.Text = totalTonage.ToString();                                
			T_FREG.Text = Round(totalFreight);
		}
		catch(Exception ex)
		{
			ShowMessageBox(ex.ToString());
		}
	}
	
	// This method should be moved to a sperate class
	private string Round(decimal decimalValue) {
		return (Math.Round(decimalValue, 2, MidpointRounding.AwayFromZero)).ToString();
	}
