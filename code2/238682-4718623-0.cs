            IList<Type> typeList = new List<Type>();
            foreach(object item in args)
            {
                typeList.Add(item.GetType());
            }
            typeList.ToArray();
