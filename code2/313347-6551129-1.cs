    public static partial class Levitate
    {
        public static Tuple<int, int> UnPack(this int value)
        {
            uint sign = (uint)value & 0x80000000;
            int small = ((int)sign >> 28) | (value & 0x0F);
            int big = value & 0xFFF0;
            return new Tuple<int, int>(small, big);
        }
    }
    int a = 10;
    a.UnPack();
