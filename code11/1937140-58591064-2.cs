    Dictionary<string, Data_Obj> Data_Dictionary= new Dictionary<string, Data_Obj>();
    using (StreamReader sr = new StreamReader(dir))
    {
        while (sr.Peek() >= 0)
        {
            String str;
            string[] strArray;
            str = sr.ReadLine();
            strArray = str.Split(',');
            Data_Obj obj;
            if(!Data_Dictionary.ContainsKey(strArray[0])
            {
                obj = new Data_Obj();
                obj.card= strArray[0];
                if(int.TryParse(strArray[1].Split(':')[0], out int hour) == true) &&
                   int.TryParse(strArray[1].Split(':')[1], out int minute) == true) &&
                   int.TryParse(strArray[2].Substring(0, 2), out int day) == true) &&
                   int.TryParse(strArray[2].Substring(2, 2), out int month) == true) &&
                   int.TryParse(strArray[2].Substring(4, 2), out int year) == true)
                {
                    obj.EnTime = new DateTime(year,month, day, hour, minute, 0, 0);
                    obj.ExTime = DateTime.MinValue;
                }
                else
                {
                    throw new FormatException("Format of dataLine must be: 00001,07:57,010619,1,001");
                }
    
                obj.DeviceNo = Int32.Parse(strArray[3]);
                obj.DeviceID = strArray[4];
                Data_Dictionary.Add(obj.card, obj);
            }
            else
            {
                obj = Data_Dictionary[strArray[0]];
                if(int.TryParse(strArray[1].Split(':')[0], out int hour) == true) &&
                   int.TryParse(strArray[1].Split(':')[1], out int minute) == true) &&
                   int.TryParse(strArray[2].Substring(0, 2), out int day) == true) &&
                   int.TryParse(strArray[2].Substring(2, 2), out int month) == true) &&
                   int.TryParse(strArray[2].Substring(4, 2), out int year) == true)
                {
                    DateTime currentValue = new DateTime(year,month, day, hour, minute, 0, 0);
                    if(obj.EnTime <= currentValue)
                    {
                        if(currentValue > obj.Extime)
                        {
                            obj.ExTime = currentValue;
                        }
                    }
                    else
                    {
                        if(obj.EnTime > obj.Extime)
                        {
                            obj.ExTime = obj.EnTime;
                        }
                        obj.EnTime = currentValue;
                    }
                }
                else
                {
                    throw new FormatException("Format of dataLine must be: 00001,07:57,010619,1,001");
                }
            }
        }
    }
