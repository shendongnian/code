    // probably "static" should be added (depends on GenerateAnotherNum routine)
    public int[] Shuffle(int[] Sequence)
    {
        // public method's arguments validation
        if (null == Sequence)
            throw new ArgumentNullException(nameof(Sequence));
        // No need in Array if you want to modify Sequence
        for(int s = 0; s < Sequence.Length - 1; s++)
        {
            int GenObj = GenerateAnotherNum(s, Sequence.Length); // pleace, note the range
            // swap procedure: note, var h to store initial Sequence[s] value
            var h = Sequence[s];          
            Sequence[s] = Sequence[GenObj];
            Sequence[GenObj] = h;
        }
        return Sequence;
    }
