    using System;
    static class ArraySliceExt
    {
        public static ArraySlice2D<T> Slice<T>(this T[,] arr, int firstDimension)
        {
            return new ArraySlice2D<T>(arr, firstDimension);
        }
    }
    class ArraySlice2D<T>
    {
        private readonly T[,] arr;
        private readonly int firstDimension;
        private readonly int length;
        public int Length { get { return length; } }
        public ArraySlice2D(T[,] arr, int firstDimension)
        {
            this.arr = arr;
            this.firstDimension = firstDimension;
            this.length = arr.GetUpperBound(1) + 1;
        }
        public T this[int index]
        {
            get { return arr[firstDimension, index]; }
            set { arr[firstDimension, index] = value; }
        }
    }
    public static class Program
    {
        static void Main()
        {
            double[,] d = new double[,] { { 1, 2, 3, 4, 5 }, { 5, 4, 3, 2, 1 } };
            var slice = d.Slice(0);
            for (int i = 0; i < slice.Length; i++)
            {
                Console.WriteLine(slice[i]);
            }
        }
    }
