    // <GetDiff>d__1
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    [CompilerGenerated]
    private sealed class <GetDiff>d__1 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IDisposable, IEnumerator
    {
        private int <>1__state;
        private int <>2__current;
        private int <>l__initialThreadId;
        private int start;
        public int <>3__start;
        private int end;
        public int <>3__end;
        int IEnumerator<int>.Current
        {
            [DebuggerHidden]
            get
            {
                return <>2__current;
            }
        }
        object IEnumerator.Current
        {
            [DebuggerHidden]
            get
            {
                return <>2__current;
            }
        }
        [DebuggerHidden]
        public <GetDiff>d__1(int <>1__state)
        {
            this.<>1__state = <>1__state;
            <>l__initialThreadId = Environment.CurrentManagedThreadId;
        }
        [DebuggerHidden]
        void IDisposable.Dispose()
        {
        }
        private bool MoveNext()
        {
            switch (<>1__state)
            {
            default:
                return false;
            case 0:
                <>1__state = -1;
                break;
            case 1:
                <>1__state = -1;
                start++;
                break;
            }
            if (start < end)
            {
                <>2__current = start;
                <>1__state = 1;
                return true;
            }
            return false;
        }
        bool IEnumerator.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            return this.MoveNext();
        }
        [DebuggerHidden]
        void IEnumerator.Reset()
        {
            throw new NotSupportedException();
        }
        [DebuggerHidden]
        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            <GetDiff>d__1 <GetDiff>d__;
            if (<>1__state == -2 && <>l__initialThreadId == Environment.CurrentManagedThreadId)
            {
                <>1__state = 0;
                <GetDiff>d__ = this;
            }
            else
            {
                <GetDiff>d__ = new <GetDiff>d__1(0);
            }
            <GetDiff>d__.start = <>3__start;
            <GetDiff>d__.end = <>3__end;
            return <GetDiff>d__;
        }
        [DebuggerHidden]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator();
        }
    }
