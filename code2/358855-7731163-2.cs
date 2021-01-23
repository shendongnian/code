    public Point? findmatch(int[] haystack, int[] needle)
    {
        var firstpixel = needle[0];
        for (int y = 0; y < haystack_height - needle_height; y++)
            for (int x = 0; x < haystack_width - needle_width; x++)
            {
                if (haystack[y * haystack_width + x] == firstpixel)
                {
                    var matched = checkmatch(haystack, needle, x, y);
                    if (matched)
                        return (new Point(x, y));
                }
            }
        return null;
    }
