    goodDictionary.Keys.All(k=>
        {
            List<string> otherVal;
            if(!testDictionary.TryGetValue(k,out otherVal))
            {
                return false;
            }
            return goodDictionary[k].SequenceEquals(otherVal);
        })
