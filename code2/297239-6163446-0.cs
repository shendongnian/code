    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace LeakyAbstractions
    {
        struct TypeA {}
        struct TypeB {}
        struct TypeC {}
        [StructLayout(LayoutKind.Explicit)] internal struct AnyMessage {
            [FieldOffset(0)] public TypeA A;
            [FieldOffset(0)] public TypeB B;
            [FieldOffset(0)] public TypeC C;
            AnyMessage(TypeA a) { A = a; }
            AnyMessage(TypeB b) { B = b; }
            AnyMessage(TypeC c) { C = c; }
            public static implicit operator TypeA(AnyMessage msg) { return msg.A; }
            public static implicit operator TypeB(AnyMessage msg) { return msg.B; }
            public static implicit operator TypeC(AnyMessage msg) { return msg.C; }
            public static implicit operator AnyMessage(TypeA a) { return new AnyMessage { A = a }; }
            public static implicit operator AnyMessage(TypeB b) { return new AnyMessage { B = b }; }
            public static implicit operator AnyMessage(TypeC c) { return new AnyMessage { C = c }; }
        }
        public class X
        {
            public static void Main(string[] s) 
            {
                var anyMessages = new List<AnyMessage> { 
                    new TypeA(),
                    new TypeB(),
                    new TypeC(),
                };
                TypeA a = anyMessages[0];
                TypeB b = anyMessages[1];
                TypeC c = anyMessages[2];
                anyMessages.Add(a);
                anyMessages.Add(b);
                anyMessages.Add(c);
            }
        }
    }
