            Decimal percent = 55.76M;
            String strPercent = String.Format("{0:0.0}%", percent);
            Decimal dollars = 33.5M;
            String strDollars = String.Format("{0:C}", dollars);
            Decimal parsedDollars = Decimal.Parse(strDollars, NumberStyles.Currency);
            if (strPercent.Contains(NumberFormatInfo.CurrentInfo.PercentSymbol))
            {
                strPercent = strPercent.Replace(
                    NumberFormatInfo.CurrentInfo.PercentSymbol,
                    String.Empty);
            }
            
            Decimal parsedPercent = Decimal.Parse(strPercent);
