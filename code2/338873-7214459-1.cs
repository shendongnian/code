        public static bool returnDecimalFromZl(string dataToCheck, out decimal value) {
            if ((dataToCheck.Trim() != "")  && (dataToCheck.Contains(" zł"))) {
                try {
                    value = Decimal.Parse(dataToCheck.Trim(), NumberStyles.Number | NumberStyles.AllowCurrencySymbol);
                    return true;
                } catch {
                    value = 0m;
                    return false;
                }
            }
            value = 0m;
            return false;
        }
