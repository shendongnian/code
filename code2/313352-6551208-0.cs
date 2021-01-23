            var value = "";
            int? age;
            if (value != string.Empty)
            {
                age = Int32.Parse(value);
            }
            else
            {
                age = null;
            }
            age = (value == string.Empty) ? (int?)null : Int32.Parse(value);
