    public static class SomeWrapperExtensions
    {
        public static ActualRec ToActualRec(
            this ISomeWrapper wrapper)
        {
            return ((SomeWrapper)someWrapper).SomeInfo;
        }
    }
