        public static void Subscribe(string token, Action<object> callback)
        {
            if (!pl_dict.ContainsKey(token))
            {
                var list = new List<Action<object>>();
                list.Add(callback);
                pl_dict.Add(token, list);
            }
            else
            {
                bool found = false;
                //foreach (var item in pl_dict[token])
                //    if (item.Method.ToString() == callback.Method.ToString())
                //        found = true;
                if (!found)
                    pl_dict[token].Add(callback);
            }
        }
