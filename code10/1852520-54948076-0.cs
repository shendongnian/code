    public static void ForLoopWithDirectionBasedOnStep(int minValue, int maxValue, int step)
    {
        if ( step == 0 )
            throw new ArgumentException("step cannot be zero");
        //  ( initialiser                           ; condition                     ; iterator  )
        for ( int i = step > 0 ? minValue : maxValue; i >= minValue && i <= maxValue; i += step )
            Console.Write(i + " ");
    }
