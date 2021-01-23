     public decimal AutoParse(string value)
        {
            if (Convert.ToDecimal("3.3") == ((decimal)3.3))
            {
                return Convert.ToDecimal(value.Replace(",", "."));
            }
            else
            {
                return Convert.ToDecimal(value.Replace(".", ","));
            }
        }
