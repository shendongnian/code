    // probably "static" should be added
    public int[] Shuffle(int[] Sequence)
    {
        if (null == Sequence)
            throw new ArgumentNullException(nameof(Sequence));
        // No need in Array if you want to modify Sequence
        for(int s = 0; s < Sequence.Length - 1; s++)
        {
            int GenObj = GenerateAnotherNum(s, Sequence.Length); // pleace, note the range
            // swap procedure: 
            var h = Sequence[s];          
            Sequence[s] = Sequence[GenObj];
            Sequence[GenObj] = h;
        }
        return Sequence;
    }
