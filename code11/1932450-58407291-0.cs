...
           json = "{\"Items\":[{ \"Name\":\"Ballpen\", \"Price\":12.3 },{ \"Name\":\"Pencil\", \"Price\":3.21 }],\"Date\":\"21112019\"}";
            Dictionary<string, object> la = JSON.Deserialize<Dictionary<string, object>>(json);
            foreach (var data in la)
            {
                Console.WriteLine("Key=" + data.Key);
                Console.WriteLine("Value=" + data.Value.ToString());
                Type t = data.Value.GetType();
                MemberInfo[] members = t.GetMembers(BindingFlags.NonPublic |
                BindingFlags.Instance);
                String sType = "";
                foreach (MemberInfo member in members)
                {
                    Object oValue;
                    if(member.Name == "Type")
                    {
                        
                        oValue = GetValue(member, data.Value);
                        sType = oValue.ToString();
                        Console.WriteLine(member.Name + "=" + oValue);
                        //member.MemberType.GetType();                    
                    }
                    if (member.Name == "StringValue")
                    {   
                        if(sType == "String")
                        {
                            oValue = GetValue(member, data.Value);
                            Console.WriteLine(member.Name + "=" + oValue);
                        }
                        
                    }
                }
                Console.WriteLine();
                Console.WriteLine();
            }
...
 i need to downcast to FieldInfo or PropertyInfo to get the member's value
        private object GetValue(MemberInfo memberInfo, object obj)
        {
            switch (memberInfo)
            {
                case FieldInfo fieldInfo:
                    return fieldInfo.GetValue(obj);
                case PropertyInfo propertyInfo:
                    return propertyInfo.GetValue(obj);
                default:
                    throw new InvalidOperationException();
            }
        }
output
Key=Items
Value=[{
 "Name": "Ballpen",
 "Price": 12.3
}, {
 "Name": "Pencil",
 "Price": 3.21
}]
Type=Array
Key=Date
Value="21112019"
Type=String
StringValue=21112019
