     public static string CastToSqlDecimalString(decimal dec)
            {
                var sqlDecimal = new System.Data.SqlTypes.SqlDecimal(dec);
                return string.Format("CAST({0} AS DECIMAL({1}, {2}))",
                            string.Format(System.Globalization.CultureInfo.InvariantCulture, "{0:G}", dec),
                            sqlDecimal.Precision,
                            sqlDecimal.Scale);
            }
