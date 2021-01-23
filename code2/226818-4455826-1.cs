    public class EnumeratorExample
    {
        // Methods
        public static IEnumerable<int> GetSource(int startPoint)
        {
            return new <GetSource>d__0(-2) { <>3__startPoint = startPoint };
        }
    
        // Nested Types
        [CompilerGenerated]
        private sealed class <GetSource>d__0 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
        {
            // Fields
            private int <>1__state;
            private int <>2__current;
            public int <>3__startPoint;
            private int <>l__initialThreadId;
            public int <index>5__3;
            public bool <keepSearching>5__2;
            public int[] <values>5__1;
            public int startPoint;
    
            // Methods
            [DebuggerHidden]
            public <GetSource>d__0(int <>1__state)
            {
                this.<>1__state = <>1__state;
                this.<>l__initialThreadId = Thread.CurrentThread.ManagedThreadId;
            }
    
            private bool MoveNext()
            {
                switch (this.<>1__state)
                {
                    case 0:
                        this.<>1__state = -1;
                        this.<values>5__1 = new int[] { 1, 2, 3, 4, 5, 6, 7 };
                        this.<keepSearching>5__2 = true;
                        this.<index>5__3 = this.startPoint;
                        while (this.<keepSearching>5__2)
                        {
                            this.<>2__current = this.<values>5__1[this.<index>5__3];
                            this.<>1__state = 1;
                            return true;
                        Label_0073:
                            this.<>1__state = -1;
                            this.<index>5__3++;
                            this.<keepSearching>5__2 = this.<index>5__3 < this.<values>5__1.Length;
                        }
                        break;
    
                    case 1:
                        goto Label_0073;
                }
                return false;
            }
    
            [DebuggerHidden]
            IEnumerator<int> IEnumerable<int>.GetEnumerator()
            {
                EnumeratorExample.<GetSource>d__0 d__;
                if ((Thread.CurrentThread.ManagedThreadId == this.<>l__initialThreadId) && (this.<>1__state == -2))
                {
                    this.<>1__state = 0;
                    d__ = this;
                }
                else
                {
                    d__ = new EnumeratorExample.<GetSource>d__0(0);
                }
                d__.startPoint = this.<>3__startPoint;
                return d__;
            }
    
            [DebuggerHidden]
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator();
            }
    
            [DebuggerHidden]
            void IEnumerator.Reset()
            {
                throw new NotSupportedException();
            }
    
            void IDisposable.Dispose()
            {
            }
    
            // Properties
            int IEnumerator<int>.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
    
            object IEnumerator.Current
            {
                [DebuggerHidden]
                get
                {
                    return this.<>2__current;
                }
            }
        }
    }
 
