        IList<Object> data = new Object[] { "A", "B", "C", "D", "E", "F", "G", "H" };
        IList<Object> xval = new Object[] { "U", "V", "W", "X", "Y", "Z" };
        IList<int> idxs = new int[] { 5, 0, 0, 0, 1, 1 };
        
        List<Object> output = new List<object>(data);
        for (int i = 0; i < xval.Count; i++)
        {
            int currentIndex = idxs[i];
            Object dataElement= data[currentIndex]; // We should insert the new element before this element.
            int elementsIndex = output.IndexOf(dataElement);
            output.Insert(elementsIndex, xval[i]);
        }
        return output;
