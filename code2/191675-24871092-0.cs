            var instance = new MyType();
            // ...
            // Use your instance in all the ways that may trigger creation of new GC roots
            // ...
   
            var weakRef = new WeakReference(instance);
            instance.Dispose();
            instance = null;
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            Assert.IsFalse(weakRef.IsAlive);
