    public void CalculateCost()//this function getting called at a button onclick
    {
        try
        {
            decimal totalTonage = Convert.ToDecimal("0");
			decimal totalPrice = Convert.ToDecimal("0");
			decimal priceCarpiTonage = Convert.ToDecimal("0");
			decimal totalFreight = Convert.ToDecimal("0");
			for(int i = 0; i < TB_COST.Data.Rows.Count; i++)
			{
				decimal containerTonage = Convert.ToDecimal(TB_COST.Data.Rows[i]["CONTON"].ToString());
				totalTonage += containerTonage;
				decimal price = Convert.ToDecimal(TB_COST.Data.Rows[i]["PROPRI"].ToString());
				totalPrice += price;
				priceCarpiTonage +=  Convert.ToDecimal(containerTonage) * price; 
				decimal decimalFreightPrice = Convert.ToDecimal(TB_COST.Data.Rows[i]["CONPRI"].ToString());
				decimal containerTonnage = Convert.ToDecimal(TB_COST.Data.Rows[i]["CONTON"].ToString());
				decimal decimalFreightBoluContainerTonnage = decimalFreightPrice/containerTonnage;
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
