    class MyClass {
        public int[] MyValues { get; protected set; }
        
        public MyClass() {
            MyValues = new [] {1, 2, 3, 4, 5};
        }
        public void foo {
            foreach (int i in MyValues) {
                Trace.WriteLine(i.ToString());
            }
        }
    }
    MyOtherClass {
        MyClass myClass;
        // ...
        void bar {
            // You can access the MyClass values in read outside of MyClass, 
            // because of the public property, but not in write because 
            // of the protected setter.
            foreach (int i in myClass.MyValues) {
                Trace.WriteLine(i.ToString());
            }
        }
    }
