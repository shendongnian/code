    var smallestValue = int.MaxValue;
    var secondSmallestValue = int.MaxValue;
    for(int row = 0; row < values.GetUpperBound(0); row++)
    {
        for (int col = 0; col < values.GetUpperBound(1); col++)
        {
            var thisValue = values[row, col];
            if (thisValue < smallestValue)
            {
                // Here you have row and col variables if you need to
                // keep track of the indexes at which the items were found
                secondSmallestValue = smallestValue;
                smallestValue = thisValue;
            }
            else if (thisValue < secondSmallestValue)
            {
                secondSmallestValue = thisValue;
            }
        }
    }
