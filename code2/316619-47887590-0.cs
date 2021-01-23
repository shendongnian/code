            [TestMethod]
            public void Tests()
            {
              
                Assert.AreEqual("int",typeof(int).ToCSharpMethodReturnTypeName());
                Assert.AreEqual("int[]",typeof(int[]).ToCSharpMethodReturnTypeName());
                Assert.AreEqual("int?", typeof(int?).ToCSharpMethodReturnTypeName());
    
                Assert.AreEqual("UnitTypeFriendlyNamesExtensionsTest.Inner2<string,IDictionary<string,object>>.SubInner<int,List<byte[]>,object>", typeof(Inner2<string,IDictionary<string,object>>.SubInner<int,List<byte[]>,object>).ToCSharpMethodReturnTypeName());
    
                Assert.ThrowsException<NotImplementedException>(()=> typeof(Inner2<string, IDictionary<string, object>>.SubInner<int, List<byte[]>, object>).DeclaringType.ToCSharpMethodReturnTypeName());
    
                var t = typeof(TestGenericReturnType<DateTime>);
                var m = t.GetMethod("GetService");
                var tt = m.ReturnType;
    
                Assert.AreEqual("DateTime",tt.ToCSharpMethodReturnTypeName());
    
                Assert.AreEqual("IDictionary<string,object>",typeof(IDictionary<string,object>).ToCSharpMethodReturnTypeName());
                Assert.AreEqual("IList<int[]>",typeof(IList<int[]>).ToCSharpMethodReturnTypeName());
                Assert.AreEqual("UnitTypeFriendlyNamesExtensionsTest.Astruc?",typeof(Astruc?).ToCSharpMethodReturnTypeName());
                Assert.AreEqual("UnitTypeFriendlyNamesExtensionsTest.Inner", typeof(Inner).ToCSharpMethodReturnTypeName());
            }
