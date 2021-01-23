    using System;
    namespace SO6301703
    {
        struct s64b
        {
            public long f1;
            public long f2;
            public long f3;
            public long f4;
            public long f5;
            public long f6;
            public long f7;
            public long f8;
        }
        struct s256b
        {
            public s64b f1;
            public s64b f2;
            public s64b f3;
            public s64b f4;
        }
        struct s1kb
        {
            public s256b f1;
            public s256b f2;
            public s256b f3;
            public s256b f4;
        }
        struct s8kb
        {
            public s1kb f1;
            public s1kb f2;
            public s1kb f3;
            public s1kb f4;
            public s1kb f5;
            public s1kb f6;
            public s1kb f7;
            public s1kb f8;
        }
        struct s64kb
        {
            public s8kb f1;
            public s8kb f2;
            public s8kb f3;
            public s8kb f4;
            public s8kb f5;
            public s8kb f6;
            public s8kb f7;
            public s8kb f8;
    
        }
        struct s512kb
        {
            public s64kb f1;
            public s64kb f2;
            public s64kb f3;
            public s64kb f4;
            public s64kb f5;
            public s64kb f6;
            public s64kb f7;
            public s64kb f8;
        }
        struct s1Mb
        {
            public s512kb f1;
            public s512kb f2;
    
        }
        class Program
        {
            static void Main(string[] args)
            {
                unsafe { Console.WriteLine(sizeof(s1Mb)); }
                s1Mb test;
            }
        }
    }
