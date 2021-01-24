    IEnumerable<int[]> GenerateRoll(int dies, int dice_faces)
    {
        var allFaces = Enumerable.Range(1, dice_faces).ToArray();
        var allOnes = Enumerable.Repeat(1, dies);
        var count = (int)Math.Pow(dice_faces, dies);
        return
            Enumerable.Range(0, count)
            .Select(roll => ToBaseX(roll, dice_faces, allFaces, allOnes.ToArray()));                    
    }
    int[] ToBaseX(long value, int baseValue, int[] target, int[] buffer)
    {
        var i = buffer.Length;
        do
        {
            buffer[--i] = target[value % baseValue];
            value = value / baseValue;
        }
        while (value > 0);
        return buffer;
    }
