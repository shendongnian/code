using NUnit.Framework;
using PostSharp;
using PostSharp.Patterns.Model;
using System;
namespace DisposableTestProject
{
    public class DisposableDependency : IDisposable
    {
        public bool IsDisposed { get; private set; }
        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
    [Disposable]
    public class Class1
    {
        [Child]
        public DisposableDependency DepencencyInClass1 { get; } = new DisposableDependency();
    }
    public class Class2 : Class1
    {
        [Child]
        public DisposableDependency DepencencyInClass2 { get; } = new DisposableDependency();
    }
    public class Tests
    {
        [Test]
        public void TestClass1()
        {
            Class1 class1 = new Class1();
            Assert.IsFalse(class1.DepencencyInClass1.IsDisposed);
            Post.Cast<Class1, IDisposable>(class1).Dispose();
            Assert.IsTrue(class1.DepencencyInClass1.IsDisposed);
        }
        [Test]
        public void TestClass2()
        {
            Class2 class2 = new Class2();
            Assert.IsFalse(class2.DepencencyInClass1.IsDisposed);
            Assert.IsFalse(class2.DepencencyInClass2.IsDisposed);
            Post.Cast<Class2, IDisposable>(class2).Dispose();
            Assert.IsTrue(class2.DepencencyInClass1.IsDisposed);
            Assert.IsTrue(class2.DepencencyInClass2.IsDisposed);
        }
    }
}
