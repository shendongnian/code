    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    
    public class ComObjectManager : IDisposable
    {
        private Stack<object> _comObjects = new Stack<object>();
        public TComObject Get<TComObject>(Func<TComObject> getter)
        {
            var comObject = getter();
            _comObjects.Push(comObject);
            return comObject;
        }
        public void Dispose()
        {
            while (_comObjects.Count > 0)
                Marshal.ReleaseComObject(_comObjects.Pop());
        }
    }
