        public class Foo
        {
            private static int m_Counter = 0;
            public int Id { get; set; }
            public Foo()
            {
                this.Id = System.Threading.Interlocked.Increment(ref m_Counter);
            }
        }
