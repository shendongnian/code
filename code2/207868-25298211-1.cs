            var _OrderedDictionary = new System.Collections.Specialized.OrderedDictionary();
            _OrderedDictionary.Add("testKey1", "testValue1");
            _OrderedDictionary.Add("testKey2", "testValue2");
            _OrderedDictionary.Add("testKey3", "testValue3");
            var k = _OrderedDictionary.Keys.GetEnumerator();
            var v = _OrderedDictionary.Values.GetEnumerator();
            while (k.MoveNext() && v.MoveNext()) {
                var key = k.Current; var value = v.Current;
            }
