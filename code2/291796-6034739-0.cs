    public static class MyMathExtension
    {
        public static int factorial(this int x)
        {
            if (x <= 1)
                return 1;
            else
                return x * (x - 1).factorial();
        }
    }
