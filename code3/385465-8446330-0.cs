    protected bool GetProductSalesPic(object Date)
        {
            DateTime actDate = (DateTime)Date;
            if (DateTime.Now.AddDays(-30) < actDate)
            {
                return true;
            }
            else
            {
            return false;
            }
        } 
