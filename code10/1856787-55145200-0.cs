     private void JoinList(List<List<string>> listToJoin, int keysNumber, int paddingAfterKeys = 0)
        {
            // you need the padding if an element is found only in the second list
            // this is a list that will be added to the result 
            var paddingList = new List<string>();
            for (var i = 0; i < paddingAfterKeys; i++)
            {
                // feel free to change it to null or what value fit your solution
                paddingList.Add("0");
            }
            foreach (var t in listToJoin)
            {
                // create a key
                var keyString = string.Join(',', t.Take(keysNumber));
                if (result.TryGetValue(keyString, out var fieldsList))
                {
                    // if the key already exist just add the values except the keys values this way you won't get duplicate keys
                    fieldsList.AddRange(t.Skip(keysNumber));
                }
                else
                {
                    // get the keys, pad the list if needed and the rest of the keys
                    fieldsList = t.Take(keysNumber).ToList();
                    fieldsList.AddRange(paddingList);
                    fieldsList.AddRange(t.Skip(keysNumber));
                    // add new key to the dictionary and set the value in my program the result was a private variable of the class for the ease of use.
                    result[keyString] = fieldsList;
                }
            }
        }
