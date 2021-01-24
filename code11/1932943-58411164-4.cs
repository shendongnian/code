    public static class Ensure
    {
        public static void True([DoesNotReturnIf(false)] bool condition)
        {
            if (!condition)
            {
                 throw new Exception("!!!");   
            }
        }
    }
