        private static void AssertDictionary(dynamic expected, dynamic actual)
        {
            // you will be able to call methods as:
            actual.Add(1, new Person()); // intelisence will not help you you have to be carefull with the dynamic type
            // I dont recoment using it if there is a work around
        }
