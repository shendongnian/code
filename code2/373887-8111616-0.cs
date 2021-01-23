    using System;
    
    public class Program
    {
        public delegate R Deleg1<R,T1>(T1 arg);
        public delegate R Deleg2<R,T1,T2>(T1 arg1, T2 arg2);
        public delegate R Deleg3<R,T1,T2,T3>(T1 arg1, T2 arg2, T3 arg3);
    
        public static void AcceptAny<R,T1>(Deleg1<R,T1> del) {  /**/ }
        public static void AcceptAny<R,T1,T2>(Deleg2<R,T1,T2> del) {  /**/ }
        public static void AcceptAny<R,T1,T2,T3>(Deleg3<R,T1,T2,T3> del) {  /**/ }
    
        public static void Main(string[] args)
        {
        }
    }
