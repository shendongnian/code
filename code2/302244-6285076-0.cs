        public DataTable ParseToTable(string Value)
        {
            if (someCondition)
                return ParseInternal<Pair>(Value, (s, i) => new Pair(s, i));
            else
                return ParseInternal<string>(Value, (s, i) => s);
        }
        private DataTable ParseInternal<T>(string Value, Func<string,int,T> newItem)
        {
            List<T> list = new List<T>();
            string tempStr;
            int integer = -1;
            foreach (string s in ((string)Value).Split(new char[1] { ',' }))
            {
                if (int.TryParse(s, out integer))
                {
                    tempStr = NameValue.AllKeys[integer];
                    list.Add(newItem(tempStr, integer));
                }
            }
            return list.ExtensionMethodForLists();
        }
