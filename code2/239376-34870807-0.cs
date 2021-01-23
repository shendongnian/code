    string s = "kg g L000145.50\r\n";
            char theCharacter = '.';
            var getNumbers = (from t in s
                              where char.IsDigit(t) || t.Equals(theCharacter)
                              select t).ToArray();
            var _str = string.Empty;
            foreach (var item in getNumbers)
            {
                _str += item.ToString();
            }
            double _dou = Convert.ToDouble(_str);
            MessageBox.Show(_dou.ToString("#,##0.00"));
