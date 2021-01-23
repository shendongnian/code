    LogicalOperation.OperationStack.Push()/Pop().
    //OperationStack.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using System.Runtime.Remoting.Messaging;
    
    namespace LogicalOperation
    {
      public static class OperationStack
      {
        private const string OperationStackSlot = "OperationStackSlot";
    
        public static IDisposable Push(string operation)
        {
          OperationStackItem parent = CallContext.LogicalGetData(OperationStackSlot) as OperationStackItem;
          OperationStackItem op = new OperationStackItem(parent, operation);
          CallContext.LogicalSetData(OperationStackSlot, op);
          return op;
        }
    
        public static object Pop()
        {
          OperationStackItem current = CallContext.LogicalGetData(OperationStackSlot) as OperationStackItem;
    
          if (current != null)
          {
            CallContext.LogicalSetData(OperationStackSlot, current.Parent);
            return current.Operation;
          }
          else
          {
            CallContext.FreeNamedDataSlot(OperationStackSlot);
          }
          return null;
        }
    
        public static object Peek()
        {
          OperationStackItem top = Top();
          return top != null ? top.Operation : null;
        }
    
        internal static OperationStackItem Top()
        {
          OperationStackItem top = CallContext.LogicalGetData(OperationStackSlot) as OperationStackItem;
          return top;
        }
    
        public static IEnumerable<object> Operations()
        {
          OperationStackItem current = Top();
          while (current != null)
          {
            yield return current.Operation;
            current = current.Parent;
          }
        }
    
        public static int Count
        {
          get
          {
            OperationStackItem top = Top();
            return top == null ? 0 : top.Depth;
          }
        }
          
        public static IEnumerable<string> OperationStrings()
        {
          foreach (object o in Operations())
          {
            yield return o.ToString();
          }
        }
      }
    }
    
    
    //OperationStackItem.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace LogicalOperation
    {
      public class OperationStackItem : IDisposable
      {
        private OperationStackItem parent = null;
        private object operation;
        private int depth;
        private bool disposed = false;
    
        internal OperationStackItem(OperationStackItem parentOperation, object operation)
        {
          parent = parentOperation;
          this.operation = operation;
          depth = parent == null ? 1 : parent.Depth + 1;
        }
    
        internal object Operation { get { return operation; } }
        internal int Depth { get { return depth; } }
    
        internal OperationStackItem Parent { get { return parent; } }
    
        public override string ToString()
        {
          return operation != null ? operation.ToString() : "";
        }
    
        #region IDisposable Members
    
        public void Dispose()
        {
          if (disposed) return;
    
          OperationStack.Pop();
    
          disposed = true;
        }
    
        #endregion
      }
    }
