        public T Read<T>(object pValue)
                {
                    var splitValue = pValue.ToString().Split('.');
                    //check if it is a string template (3 separation ., 2 if not)
                    if (splitValue.Count() > 3 && splitValue[1].Substring(2, 1) == "S")
                    {
                        DataType dType;
        
                        //If we have to read string in other dataType need development to make here.
                        if (splitValue[0].Substring(0, 2) == "DB")
                            dType = DataType.DataBlock;
                        else
                            throw new Exception("Data Type not supported for string value yet.");
        
                        int length = Convert.ToInt32(splitValue[3]);
                        int start = Convert.ToInt32(splitValue[1].Substring(3, splitValue[1].Length - 3));
                        int MemoryNumber = Convert.ToInt32(splitValue[0].Substring(2, splitValue[0].Length - 2));
        
                        // the 2 first bits are for the length of the string. So we have to pass it
                        int startString = start + 2;
                        var value = ReadFull(dType, MemoryNumber, startString, VarType.String, length);
                        return (T)value;
                    }
                    else
                    {
                        var value = plc.Read(pValue.ToString());
        
                        //Cast with good format.
                        return (T)value;
                    }
    }
