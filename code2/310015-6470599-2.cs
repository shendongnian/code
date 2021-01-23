        // Make an array from any IEnumerable (array, list, etc.)
        Array MakeArray(IEnumerable parm, Type t)
        {
            if (parm == null)
                return Array.CreateInstance(t, 0);
            int arrCount;
            if (parm is IList)     // Most arrays etc. implement IList
                arrCount = ((IList)parm).Count;
            else
            {
                arrCount = 0;
                foreach (object nextMember in parm)
                {
                    if (nextMember.GetType() == t)
                        ++arrCount;
                }
            }
            Array retval = Array.CreateInstance(t, arrCount);
            int ix = 0;
            foreach (object nextMember in parm)
            {
                if (nextMember.GetType() == t)
                    retval.SetValue(nextMember, ix);
                ++ix;
            }
            return retval;
        }
