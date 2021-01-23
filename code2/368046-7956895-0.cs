       List<Type> res = new List<Type>();
            foreach (Type aType in   Assembly.LoadFile("yourdll.dll").GetTypes())
            {
                if(aType.IsSubclassOf(typeof(Control)))
                    res.Add(aType);
            }
          
