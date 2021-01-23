    class Test
    {
        public int id;
        public int[] vals; //A SORTED list of integers
    
        public bool BinaryContains(int[] values)
        {
            for (int i = 0; i < values.Length; i++)
                if (values[i] >= vals[0] && values[i] <= vals[vals.Length])
                {
                    //Binary search vals for values[i]
                    //if match found return true
                }
            return false;
        }
    }
