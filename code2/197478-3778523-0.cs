    public unsafe class CppFunctionImport
    {
        [DllImport("ImageProcessingCpp.dll", EntryPoint = "PerformMovingAverage", ExactSpelling = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]//!-!
        public static extern void PerformMovingAverage
        (
            ref byte *image,
            int width,
            int height,
            int stride,
            int kernelSize
        );
    }
