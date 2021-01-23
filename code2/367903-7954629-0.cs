    using System;
    class BaseClass : IDisposable {
        bool _guidremoved = false;
        public void RemoveGuid() {
            if (!_guidremoved) {
                _guidremoved = true;
                // your logic here                
            }
        }
        public void Dispose() {
            RemoveGuid();
        }
    }
    class Derived : BaseClass { 
    }
    static class Program {
        static void Main(string[] args) {
            using (Derived d = new Derived()) { 
                // do stuff here...
                d.RemoveGuid();
            } // when we exit this block, Dispose is called
        }
    }
