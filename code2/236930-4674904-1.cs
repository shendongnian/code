    using System;
    using System.Runtime.InteropServices;
    namespace TestDrive
    {
        class Program
        {
            static void Main()
            {
                byte[] a = { 1,2,3,4,5,6,7,8} ;
                byte[] b = { 1,2,3,4,5,0,7,8} ;
                byte[] c = { 1,2,3,4,5,6,7,8} ;
                bool isMatch ;
                isMatch = TimestampCompare( a , b ) ; // returns false
                isMatch = TimestampCompare( a , c ) ; // returns true
                return ;
            }
            
            [DllImport("msvcrt.dll", CallingConvention=CallingConvention.Cdecl)]
            static extern int memcmp(byte[] x , byte[] y , UIntPtr count ) ;
            
            static unsafe bool TimestampCompare( byte[] x , byte[] y )
            {
                const int LEN = 8 ;
                UIntPtr   cnt = new UIntPtr( (uint) LEN ) ;
                // check for reference equality
                if ( x == y ) return true ;
                if ( x == null || x.Length != LEN || y == null || y.Length != LEN )
                {
                    throw new ArgumentException() ;
                }
                return ( memcmp(  x ,  y , cnt ) == 0 ? true : false ) ;
            }
        }
    }
