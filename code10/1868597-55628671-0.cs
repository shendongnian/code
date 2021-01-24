     if (string.IsNullOrWhiteSpace(dataRow["APP_STATUS"].ToString()))
     {
        return MyEnum.None;
     }
     Enum.TryParse(dataRow["APP_STATUS"].ToString(), out MyEnum status);
     
