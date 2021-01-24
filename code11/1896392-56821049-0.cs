    public T Convert<T>(dynamic obj) where T:class,new()
        {
            T myob = null;
            if (obj !=null && obj is T)
            {
                myob = obj as T;
            }
            else if (obj is string)
            {
                //convert to type
                myob = JsonConvert.DeserializeObject<T>(obj);
                
            }
            return myob;
        }
