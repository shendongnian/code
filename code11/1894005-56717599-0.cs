    public static class Canvas
    {
       
        public static char[,] Draw(uint width, uint height)
        {
            char[,] page = new char[width + 4, height + 4];
            for (uint i = 1; i < width + 3; i++) //goes from 1 to 4 - 0 is null
            {
                for (uint j = 1; j < height + 3; j++) //goes from 1 to 4 - 5 is null
                {
                    page[i, j] = '1';
                }
            }
            for (uint i = 0; i < width + 5; i++)  // goes from 0 to 6, but array ends at 5
            {
                page[0, i] = '-';
            }
            for (uint i = 0; i < width + 5; i++) // goes from 0 to 6, but array ends at 5
            {
                page[height + 4, i] = '-'; //the argument "height +4" throw the position out of the array, because arrays starts at 0
            }
            for (uint j = 1; j < height + 4; j++)
            {
                page[j, 0] = '|';
            }
            for (uint j = 1; j < height + 4; j++)
            {
                page[j, width + 4] = '|'; //the argument "width +4" throw the position out of the array, because arrays starts at 0
            }
            return page;
        }
    }
