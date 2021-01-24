    List<int[]> Targ = new List<int[]>()
    {
        new int[] {0,1,2},
        new int[] {2,3,4},
        new int[] {4,5,6},
        new int[] {7,8,9},
        new int[] {9,10,11},
        new int[] {11,12,13},
    };
    List<List<int[]>> ArrLists = new List<List<int[]>>();
    List<int[]> Element = new List<int[]>();
    for ( int i = 0; i < Targ.Count - 1; i++ )
    {
        bool Added = false;
        for ( int j = 0; j < Targ[i].Length; j++)
        {
            // checking
            if ( Targ[i+1].Contains(Targ[i][j]) )
            {
                Element.Add(Targ[i]);
                Added = true;
                break;
            }
        }
        // if array(int) is not added, it means there's a difference between elements.
        if ( !Added )
        {
            ArrLists.Add(Element);
            Element = new List<int[]>();
            Element.Add(Targ[i]);
        }
    }
    // Add Last Element to list
    ArrLists.Add(Element);
