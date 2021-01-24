    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SoFluentExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var en = Enumerable.Range(0, 10).Concat(Enumerable.Range(0, 10));
    
                var result = en
                                .ReplaceAll(1, 100)
                                .Given(true)
                                .ReplaceAll(2, 200)
                                .Given(false)
                                .ReplaceAll(3,300)
                                .ToArray();
            }
        }
    
        public class MyFluentEnumerableWithCondition<T> : IEnumerable<T>
        {
            public IEnumerable<T> en { get; private set; }
            public bool condition { get; private set; }
    
            public MyFluentEnumerableWithCondition(IEnumerable<T> en, bool condition)
            {
                this.en = en;
                this.condition = condition;
            }
            public IEnumerator<T> GetEnumerator()
            {
                return en.GetEnumerator();
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return en.GetEnumerator();
            }
        }
        public class MyFluentReplacerEnumerable<T> : IEnumerable<T> 
        {
            private IEnumerable<T> en;
            private T foo;
            private T bar;
            public MyFluentReplacerEnumerable(IEnumerable<T> en, T foo, T bar)
            {
                this.en = en;
                this.foo = foo;
                this.bar = bar;
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                return new MyEnumerator(en.GetEnumerator(), foo, bar);
            }
    
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            private class MyEnumerator : IEnumerator<T>
            {
                private IEnumerator<T> en;
                private T foo;
                private T bar;
                public MyEnumerator(IEnumerator<T> enumerator,T foo, T bar)
                {
                    this.en = enumerator;
                    this.foo = foo;
                    this.bar = bar;
                }
                public T Current => replace(en.Current,foo,bar);
    
                private T replace(T current, T foo, T bar)
                {
                    return current.Equals(foo) ? bar : current;
                }
    
                object IEnumerator.Current => Current;
    
                public bool MoveNext()
                {
                    return en.MoveNext();
                }
    
                public void Reset()
                {
                    en.Reset();
                }
    
                #region IDisposable Support
                private bool disposedValue = false; 
    
                protected virtual void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                            en.Dispose();
                        }
                        disposedValue = true;
                    }
                }
                public void Dispose()
                {
                    Dispose(true);
                }
                #endregion
            }
        }
        public static class MyExtension
        {
            public static IEnumerable<T> ReplaceAll<T>(this IEnumerable<T> en,T foo, T bar)
            {
                return new MyFluentReplacerEnumerable<T>(en, foo, bar);
            }
    
            public static MyFluentEnumerableWithCondition<T> ReplaceAll<T>(this MyFluentEnumerableWithCondition<T> en, T foo, T bar)
            {
                if (!en.condition)
                    return en;
                return new MyFluentEnumerableWithCondition<T>(en.en.ReplaceAll(foo,bar),true);
            }
            public static MyFluentEnumerableWithCondition<T> Given<T>(this IEnumerable<T> en, bool condition)
            {
                return new MyFluentEnumerableWithCondition<T>(en, condition);
            }
        }
        
    }
