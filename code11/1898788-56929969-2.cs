    public void PerformCalculations()//this function getting called at a button onclick
    {
        try
        {
    		CalculationsResult calculations = new CalculationsResult();
    		
            for(int i = 0; i < TB_COST.Data.Rows.Count; i++)
            {
                DoMyCalculation(calculations, TB_COST.Data.Rows[i]);
                // Call other calculations
            }
            decimal productPrice = calculations.PriceCarpiTonage / calculations.TotalTonage;
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
    
    private void DoMyCalculation(CalculationsResult calculations, DataRow row)
    {
    	calculations.TotalPrice += (decimal)row["MyColumn"];
    }
    
    public class CalculationsResult 
    {
        public decimal TotalTonage { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PriceCarpiTonage { get; set; }
    }
