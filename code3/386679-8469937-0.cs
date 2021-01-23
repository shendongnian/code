    class itemsorter : IComparer
    {
        public int compare(object a, object b)
        {
            int resultA, resultB;
            bool markA = int.TryParse(((lvitem)a).text, out resultA);
            bool markB = int.TryParse(((lvitem)b).text, out resultB)
    
            // They are number.
            if (markA && markB)
            {
                if (resultA > resultB)
                    return 1;
                else if (resultA < resultB)
                    return -1;
                else
                    return 0;
            }
    
    
            // a can convert to number,
            // b can't.
            if (markA && !markB)
            {
                return 1;
            }
    
            // b can convert to number,
            // a can't.
    
            if(!markA && markB)
            {
                return -1;
            }
    
        }
    }
