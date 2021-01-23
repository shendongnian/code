        public string ToString(MyObjectClass object)
        {
            Type MyObjectType = object.GetType();
            PropertyInfo[] propertyInfoList = MyObjectType.GetProperties();
            string result = "";
            foreach(PropertyInfo propertyInfo in propertyInfoList)
            {
                result += string.Format("{0}={1} ", propertyInfo.Name, propertyInfo.GetValue(sheetDbEntry));
            }
            return result;
        }
