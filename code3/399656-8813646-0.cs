	public class MyObject
        {
            static int idCount = 0;
            private int _objectID;
            public int ObjectID
            {
                get { return _objectID; }
            }
            public MyObject()
            {
                idCount++;
                _objectID = idCount;
            }
        }
