       public override bool IsValid(object value)     { 
           var stringValue = Convert.ToString(value, CultureInfo.CurrentCulture); 
    
           if (String.IsNullOrEmpty(stringValue))
           {
                return true;
           }
            int tmp;
             if(int.TryParse(stringValue, out tmp))
             {
                 return tmp >= Min && tmp <= Max;
             } 
            return false; 
        }
