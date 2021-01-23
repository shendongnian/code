    public class RangeDivider
    {
        public int Min;
        public int CutOff;
        public int Max;
        public int NumDivisions;
        public RangeDivider(int min, int cutOff, int max, int numDivisions)
        {
            Min = min;
            CutOff = cutOff;
            Max = max;
            NumDivisions = numDivisions;
            System.Diagnostics.Debug.Assert(Min < CutOff && CutOff < Max && numDivisions >= 2);
        }
        public int LeftSize { get { return CutOff - Min; } }
        public int RightSize { get { return Max - CutOff; } }
        public int WholeSize { get { return Max - Min; } }
        private static int divCeil(int dividend, int divisor) { return 1 + (dividend - 1)/divisor; }
        private int ReturnSize(int leftDivisions)
        {
            int rightDivisions = NumDivisions - leftDivisions;
            if (leftDivisions > 0 && rightDivisions > 0)
            {
                return Math.Max(divCeil(LeftSize, leftDivisions), divCeil(RightSize, rightDivisions));
            }
            else
            {   //Must have at least 1 division each side of cutoff
                return int.MaxValue;
            }
        }
        public int GetSize()
        {
            var leftDivisions = NumDivisions * LeftSize / WholeSize;
            var size =  Math.Min(ReturnSize(leftDivisions), ReturnSize(leftDivisions + 1));
            Console.WriteLine("Min {0}, CutOff {1}, Max {2}, NumDivisions {3} gives a Division Size of {4}", Min, CutOff, Max, NumDivisions, size);
            return size;
        }
        public static int Get(int min, int cutOff, int max, int numDivisions) 
        { 
            return new RangeDivider(min, cutOff, max, numDivisions).GetSize(); 
        }
        public static void Test()
        {
            Get(-7,0,57,4);
            Get(-9, 0, 12, 4);
            Get(-1, 0, 7, 6);
        }
    }
