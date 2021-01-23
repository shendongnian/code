    public static string GetDescription(this ActionCode enumValue)
        {
            Array Values = System.Enum.GetValues(typeof(ActionCode));
            string description = null;
            
            foreach(int val in Values)
            {
                if(val == (int)enumValue)
                {
                    var type = typeof(ActionCode);
                    var memInfo = type.GetMember(Enum.GetName(typeof(ActionCode), val));
                    var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    description = ((DescriptionAttribute)attributes[0]).Description;
                }
            }
            return description;
        }
