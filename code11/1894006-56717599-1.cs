        public static class Canvas2
    {
        public static char[,] Draw(uint width, uint height)
        {
            char[,] page = new char[width + 4, height + 4];
            for (uint i = 1; i < width + 3; i++) 
            {
                for (uint j = 1; j < height + 3; j++) 
                {
                    page[i, j] = '1';
                }
            }
            for (uint i = 0; i < width + 4; i++) 
            {
                page[0, i] = '-';
            }
            for (uint i = 0; i < width + 4; i++)
            {
                page[height + 3, i] = '-';
            }
            for (uint j = 1; j < height + 4; j++)
            {
                page[j, 0] = '|';
            }
            for (uint j = 1; j < height + 4; j++)
            {
                page[j, width + 3] = '|';
            }
            return page;
        }
    }
