        public interface IFoo
        {
            /// <summary>
            /// Don't call this directly, use DoIt from IFooExt
            /// </summary>
            [Obsolete]
            void DoItInternal();
        }
    
        public static class IFooExt
        {
            [Conditional("TRACE")]
            public static void DoIt<T>(this T t) where T : IFoo
            {
    #pragma warning disable 612
                t.DoItInternal();
    #pragma warning restore 612
            }
        }
    
        public class SomeFoo : IFoo
        {
            void IFoo.DoItInternal() { }
    
            public void Blah()
            {
                this.DoIt();
                this.DoItInternal(); // Error
            }
        }
