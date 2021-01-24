public decimal EconomicOrderQuantity
{
  get 
  {
    decimal numerator = (2 * OrderCost * AnnualSalesUnits * 100);
    decimal denominator = (HoldingRate * UnitCost);
    decimal fraction = Convert.ToDecimal(numerator / denominator);
    double final = Math.Sqrt(Convert.ToDouble(fraction));
    return Convert.ToDecimal(final);
  }
}
You need to perform some conversion prior to ensure that the proper data types are allowed to perform the calculations required.
Note that I have also rewritten the mathematical formula in a more linear way to provide a better understanding of the flow of the calculations.
