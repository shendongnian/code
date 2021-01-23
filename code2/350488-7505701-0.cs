    public interface ISample
    {
        int Calculate(int a, int b);
    }
    class SampleB : ISample
    {
        public int Calculate(int a, int b)
        {
            return a + b + 10;
        }
    }
    class SampleA : ISample
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }
