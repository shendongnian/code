           string keyString = string.Empty;
           Dictionary<string,int> dataList = new Dictionary<string,int>;
            while (first + last < l+1)
            {
                keyString = data.Substring(first, last);
                if(dataList.ContainsKey(keyString)
                   {
                     dataList[keyString] = dataList[keyString] + 1; 
                   }
                 else
                   {
                     dataList.Add(keyString,1);
                   }
                first++;
            }
