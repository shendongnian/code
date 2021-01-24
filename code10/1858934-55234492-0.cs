    class Indexer
    {
        private string[] namelist = new string[size];
        private string[] grades = new string[size + 1]; // size +1 to indicate different 
        // size
        static public int size = 10;
        public void IndexedNames()
        {
            for (int i = 0; i < size; i++)
            {
                namelist[i] = "N. A.";
                grades[i] = "F";
            }
        }
        public string this[int i, int j]
        {
            get
            {
                string tmp;
                // we need to return first array
                if (i > 0)
                {
                    tmp = namelist[i];
                }
                else
                {
                    tmp = grades[i];
                }
                return (tmp);
            }
            set
            {
                if (i > 0)
                {
                    namelist[i] = value;
                }
                else grades[i] = value;
            }
        }
    }
