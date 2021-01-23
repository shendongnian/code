    using System;
    using System.Linq;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    namespace ImmutableTests
    {
        [TestClass]
        public class AssertImmutableTests
        {
            [TestMethod]
            public void Is_int_immutable()
            {
                Assert.IsTrue(Immutable<int>());
            }
    
            [TestMethod]
            public void Is_string_immutable()
            {
                Assert.IsTrue(Immutable<string>());
            }
    
            [TestMethod]
            public void Is_custom_immutable()
            {
                Assert.IsTrue(Immutable<MyImmutableClass>());
            }
    
            [TestMethod]
            public void Is_custom_mutable()
            {
                Assert.IsFalse(Immutable<MyMutableClass>());
            }
    
            [TestMethod]
            public void Is_custom_deep_mutable()
            {
                Assert.IsFalse(Immutable<MyDeepMutableClass>());
            }
    
            [TestMethod]
            public void Is_custom_deep_immutable()
            {
                Assert.IsTrue(Immutable<MyDeepImmutableClass>());
            }
    
            [TestMethod]
            public void Is_propertied_class_mutable()
            {
                Assert.IsFalse(Immutable<MyMutableClassWithProperty>());
            }
    
            private static bool Immutable<T>()
            {
                return Immutable(typeof(T));
            }
    
            private static bool Immutable(Type type)
            {
                if (type.IsPrimitive) return true;
                if (type == typeof(string)) return true;
                var fieldInfos = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                var isShallowImmutable = fieldInfos.All(f => f.IsInitOnly);
                if (!isShallowImmutable) return false;
                var isDeepImmutable = fieldInfos.All(f => Immutable(f.FieldType));
                return isDeepImmutable;
            }
        }
    
        public class MyMutableClass
        {
            private string _field;
        }
    
        public class MyImmutableClass
        {
            private readonly string _field;
        }
    
        public class MyDeepMutableClass
        {
            private readonly MyMutableClass _field;
        }
    
        public class MyDeepImmutableClass
        {
            private readonly MyImmutableClass _field;
        }
    
        public class MyMutableClassWithProperty
        {
            public string Prop { get; set; }
        }
    }
