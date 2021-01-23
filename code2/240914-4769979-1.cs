            int clearResetCount = 0;
            Mock<IDependency> dep = new Mock<IDependency>();
            
            MyClass myclass = new MyClass(dep.Object);
            dep.Setup(s => s.Reset()).Callback(() => clearResetCount++);
            
            myclass.Clear();
            Assert.AreEqual(1, clearResetCount, "Expected clear reset count.");
