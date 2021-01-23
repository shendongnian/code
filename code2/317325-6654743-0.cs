    string pattern = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
            DateTime dt = DateTime.Now;
            string[] format = pattern.Split(new string[] { CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator }, StringSplitOptions.None);
            string newPattern = string.Empty;
            for(int i = 0; i < format.Length; i++) {
                newPattern = newPattern + format[i];
                if(format[i].Length == 1)
                    newPattern += format[i];
                if(i != format.Length - 1)
                    newPattern += CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;
            }
