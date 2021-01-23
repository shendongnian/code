        public static void SetUserLocale(string currencySymbol, bool setUiCulture)
        {
            HttpRequest Request = HttpContext.Current.Request;
            if (Request.UserLanguages == null)
                return;
            string Lang = Request.UserLanguages[0];
            if (Lang != null)
            {
                if (Lang.Length < 3)
                    Lang = Lang + "-" + Lang.ToUpper();
                try
                {
                    CultureInfo Culture = new CultureInfo(Lang);
                    if (currencySymbol != null && currencySymbol != "")
                        Culture.NumberFormat.CurrencySymbol = currencySymbol;
                    Thread.CurrentThread.CurrentCulture = Culture;
                    if (setUiCulture)
                        Thread.CurrentThread.CurrentUICulture = Culture;
                }
                catch
                { /// avoid invalid language selection bombing }
            }
        }
