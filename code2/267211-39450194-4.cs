            public IEnumerable<int> Numbers()
            {
                return EnumeratorMonad.Build<int>(async Yield =>
                {
                    await Yield(11);
                    await Yield(22);
                    await Yield(33);
                });
            }
            [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethod]
            public void TestEnum()
            {
                var v = Numbers();
                var e = v.GetEnumerator();
                int[] expected = { 11, 22, 33 };
                Numbers().Should().ContainInOrder(expected);
            }
