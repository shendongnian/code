    using System;
    
    namespace ConsoleApplication21
    {
        public interface INextPrevious<out TElement>
        {
            TElement NextElement { get; }
            TElement PreviousElement { get; }
        }
    
        public class XSomething : INextPrevious<XSomething>
        {
            public XSomething NextElement
            {
                get { throw new NotImplementedException(); }
            }
    
            public XSomething PreviousElement
            {
                get { throw new NotImplementedException(); }
            }
        }
    
        public class MySpecialCollection<T>
            where T : INextPrevious<T>
        {
            public T GetElementByShoeSize(int shoeSize)
            {
                throw new NotImplementedException();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var coll = new MySpecialCollection<XSomething>();
                XSomething element = coll.GetElementByShoeSize(39);
                XSomething nextElement = element.NextElement;
            }
        }
    }
