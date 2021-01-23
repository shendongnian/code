    protected void CustomValidator_DateTime(object source, ServerValidateEventArgs args)
        {
            IFormatProvider culture = new CultureInfo("en-AU", true);
            try
            {
                String[] formats = { "dd MM yyyy HH:mm", "dd/MM/yyyy HH:mm", "dd-MM-yyyy HH:mm" };
                DateTime dt1;
                DateTime.TryParseExact(args.Value, formats, culture, DateTimeStyles.AdjustToUniversal, out dt1);
                if (dt1.ToShortDateString() != "1/01/0001")
                    args.IsValid = true;
                else
                    args.IsValid = false;
            }
            catch
            {
                args.IsValid = false;
            }
        }
