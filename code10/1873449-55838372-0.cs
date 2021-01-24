public static string[] SetData(string section, string key, string value, string[] data)
        {
            var updatedData = data;
            int sectionIndex = Array.IndexOf(data, "[" + section + "]");
            if(sectionIndex > -1)
            {
                //section found
                for(int i = sectionIndex; i < data.Length; i++)
                {
                    if (data[i].StartsWith(key))
                    {
                        //key found
                        string newData = data[i];
                        string tempString = newData.Remove(newData.LastIndexOf(":"));
                        updatedData[i] = tempString + ": " + value;
                        break;     
                    }
                    else if (data[i].StartsWith("[") && !data[i].Contains(section))
                    {
                        //key not found, end of section reached.
                        List<string> temp = data.ToList();
                        temp.Insert(i, key + ": " + value);
                        updatedData = temp.ToArray();
                        break;                
                    }
                    else if (i == data.Length - 1) //-1?
                    {
                        //key not found, end of file reached.
                        List<string> temp = data.ToList();
                        temp.Insert(i, key + ": " + value);
                        updatedData = temp.ToArray();
                        break; 
                    }
                }
                return updatedData;
            }
            else
            {
                //section not found
                updatedData = new string[data.Length + 2];
                updatedData[updatedData.Length - 2] = "[" + section + "]";
                updatedData[updatedData.Length - 1] = key + ": " + data;
                return updatedData;
            }
        }
