    [StructLayout(LayoutKind.Sequential)]
    public struct Vec3
    {
        public double X, Y, Z;
        public double Mag { get { return Math.Sqrt(X * X + Y * Y + Z * Z); } }
    }
    public unsafe class Vec3ArrayProxy
    {
        Vec3*[] ptr = null; //internal array of pointers
        public Vec3ArrayProxy(Vec3[] array)
        {
            ptr = new Vec3*[array.Length]; //allocate array
            fixed (Vec3* src = array) //src holds pointer from source array
            {
                for (int i = 0; i < array.Length; i++)
                {
                    ptr[i] = &src[i]; //take address of i-th element
                }                
            }
        }
        public Vec3ArrayProxy(Vec3ArrayProxy other)
        {
            //just use all the existing pointers
            ptr = (Vec3*[])other.ptr.Clone();
            //or I could say:
            //ptr = other.ptr;
        }
        // Access values with index
        public Vec3 this[int index]
        {
            get { return *ptr[index]; }
            set { *ptr[index] = value; }
        }
        public int Count { get { return ptr.Length; } }
        // Access the array of pointers
        public Vec3*[] PtrArray { get { return ptr; } }
        // Copy the values of original array into new array
        public Vec3[] ToArrayCopy()
        {
            Vec3[] res = new Vec3[ptr.Length];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = *ptr[i];
            }
            return res;
        }
    }
    unsafe class Program
    {
        static void Main(string[] args)
        {
            const int N = 10; //size of array
            // Allocate array in memory
            Vec3[] array = new Vec3[N];
            // Assign values into array
            for (int i = 0; i < N; i++)
            {
                array[i] = new Vec3() { X = i, Y = 0, Z = 0 };
            }
            //Build proxy to array (with pointers)
            Vec3Array A = new Vec3Array(array);
            // Reference the same pointers as A
            Vec3Array B = new Vec3Array(A); 
            // Change the original array
            array[4].X = -4;
            // Or change via a copy
            A.PtrArray[5]->Y = -5;  
            // Or assign a new value
            B[0] = B[9];            
            // Show contents of array via proxy A
            Console.WriteLine("{0,-6}|{1,6}|{2,6}|{3,6}|{4,6}", 
                "i", "X", "Y", "Z", "Mag");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("{0,6}|{1,6:F2}|{2,6:F2}|{3,6:F2}|{4,6:F3}", 
                    i + 1, A[i].X, A[i].Y, A[i].Z, A[i].Mag);
            }
        }
    }
