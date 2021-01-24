     public void UpdateProperty(string propertyName,object propertyValue)
        {
            UserInfo userInfo = new UserInfo(); // use your userInfo
            if(propertyName == "FirstName")
            {
                userInfo.FirstName = propertyValue as string;
            }
            if(propertyName == "Age")
            {
                userInfo.Age = (int)propertyValue;
            }
        }
