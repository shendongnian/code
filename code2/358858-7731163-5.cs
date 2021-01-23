    public IEnumerable<Point> FindMatches(int[] haystack, int[] needle)
    {
        var firstpixel = needle[0];
        for (int y = 0; y < haystack_height - needle_height; y++)
            for (int x = 0; x < haystack_width - needle_width; x++)
            {
                if (haystack[y * haystack_width + x] == firstpixel)
                {
                    if (checkmatch(haystack, needle, x, y))
                        yield return (new Point(x, y));
                }
            }
    }
