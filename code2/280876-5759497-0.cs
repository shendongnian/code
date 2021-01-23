     public class UpdatableList
    {
        public HashSet<string> TheList { get; private set; }
        //Returns true if new list contains different elements
        //and updates the collection.
        //Otherwise returns false.
        public bool Update(List<String> newList)
        {
            if (TheList == null)
            {
                TheList = new HashSet<string>(newList);
                return true;
            }
            foreach (var item in newList)
            {
                //This operation compares elements hash codes but not 
                //values itself.
                if (!TheList.Contains(item))
                {
                    TheList = new HashSet<string>(newList);
                    return true;
                }
            }
            //It gets here only if both collections contain identical strings.
            return false;
        }
    }
