    ArrayList clubs = new ArrayList();
    ArrayList spades = new ArrayList();
    ArrayList hearts = new ArrayList();
            
    int[] array = new int[52];
    clubs.ToArray(typeof(int)).CopyTo(array, 0);
    spades.ToArray(typeof(int)).CopyTo(array, clubs.Count);
    hearts.ToArray(typeof(int)).CopyTo(array, spades.Count);
