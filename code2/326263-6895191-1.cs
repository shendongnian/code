            var dict=new Dictionary<string,object>();
            foreach (var p in anonType.GetType().GetProperties())
            {
                object val = p.GetValue(anonType, BindingFlags.ExactBinding, null, null, null);
                //dynamic val = p.GetValue(anonType, BindingFlags.ExactBinding, null, null, null);
                dict.Add(p.Name,val));
            }
