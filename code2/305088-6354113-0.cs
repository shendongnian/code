    private TypeValues GetEnumValues(Type enumType, string description)
            {
                TypeValues wtv = new TypeValues();
                wtv.TypeValueDescription = description;
                List<string> values = Enum.GetNames(enumType).ToList();
                foreach (string v in values)
                {
                    //how to get the integer value of the enum value 'v' ?????
    
                   int value = (int)Enum.Parse(enumType, v);
    
                    wtv.TypeValues.Add(new TypeValue() { Code = v, Description = v });
                }
                return wtv;
    
            }
