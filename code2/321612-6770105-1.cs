            string quote = "\"";
            string delimiter = ",";
            string placeholder = "$";
            string output = Regex.Replace(
                input,
                quote + ".*?" + quote,
                m => m.ToString().Replace(delimiter, placeholder));
