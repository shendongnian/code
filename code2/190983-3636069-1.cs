    foreach(string[,] square in cross)
        for(int y = 0; y < square.GetUpperBound(0); y++){
            var inner = GetEnumeratedInner(square, y);
            // now do something with inner
        }
    ...
    static IEnumerable<string> GetEnumeratedInner(string[,] square, int y){
        for(int x = 0; x < square.GetUpperBound(1); x++)
            yield return square[y, x];
    }
