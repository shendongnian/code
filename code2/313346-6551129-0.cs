    public static partial class Levitate
    {
        public static Tuple<int, int> UnPack(this int value)
        {
            var small = value & 0x000F;
            var big = value & 0xFFF0;
            return new Tuple<int, int>(small, big);
        }
    }
    int a = 10;
    a.UnPack();
