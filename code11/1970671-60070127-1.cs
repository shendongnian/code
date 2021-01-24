    public class MyObject
    {
        // "defining" attributes
        public string[] definingAttributes = new string[3];
        // other attributes
        private string member4;
        private string member5;
        // ctor
        public MyObject() { }
        public bool compare(MyObject that)
        {
            bool? previousResult = null;
            // compare this object with another (that)
            for (int i = 0; i < definingAttributes.Length; i++)
            {
                if (previousResult == null)
                {
                    previousResult = definingAttributes[i] == that.definingAttributes[i];
                }
                if (definingAttributes[i] != that.definingAttributes[i])
                {
                    if (previousResult != (definingAttributes[i] == that.definingAttributes[i]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
