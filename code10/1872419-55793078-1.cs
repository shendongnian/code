    dynamic jsonObj = JsonConvert.DeserializeObject(c.oemCode);
    foreach (var obj in jsonObj.objectList)
    {
       if(obj.OptionCode.ToString().Trim().Length ==0) continue;
       OptionCode += " " + obj.OptionCode;
    }
    OptionCode = OptionCode.Trim();
