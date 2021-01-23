    Yes, You can create a Stack program without any collection.
    
    using System;
    using System.Linq;
    using System.Text;
    
    
    namespace DataStructures
    {
        class Stack
        {
            Object[] stack;
            Int32 i;
            Int32 j;
    
           public Stack(int n)
            {
                stack = new Object[n];
                i = 0;
                j = n;
            }
    
            public void Push(object item)
            {
                if (!isStackFull())
                {
                    stack[i++] = item;
                }
                else
                Console.WriteLine("Stack is Full");
            }
    
            public bool isStackFull()
            {
                if (i == j)
                    return true;
                else
                    return false;
            }
    
            public object Pop()
            {
                if (stack.Length != 0)
                    return stack[--i];
                return -1;
                Console.WriteLine("Stack is empty");
            }
    
            public object TopElement()
            {
                if (stack.Length != 0)
                    return stack[i - 1];
                return 0;
            }
        }
    
    }
    
      class Program
        {
            static void Main(string[] args)
            {
                Stack s = new Stack(5);
                s.Push(5);
                s.Push(6);
                s.Push("string");
                s.Push(8);
                s.Push("ram");
                s.Push(8);
                s.Push(8);
    
                Console.WriteLine("Peek: {0}", s.TopElement());
                Console.WriteLine("Pop: {0}", s.Pop());
                Console.WriteLine("Peek: {0}", s.TopElement());
                Console.WriteLine("pop: {0}", s.Pop());
                Console.Read();
            }
        }
    As per you convenient, you can modify above program. 
