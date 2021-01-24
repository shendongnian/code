        public static void Test()
        {
            // Creates an object
            var o1 = NoDupeObject.Get("O1", 10, new DateTime(2020, 01, 01));
            // Creates another object
            var o2 = NoDupeObject.Get("O2", 10, new DateTime(2020, 01, 01));
            // Gets a copy of the first object
            var o3 = NoDupeObject.Get("O1", 10, new DateTime(2020, 01, 01));
            Debug.Assert(o1 != o2);
            Debug.Assert(o1 == o3);
        }
