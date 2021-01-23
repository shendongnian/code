    using System;
    using NUnit.Framework;
    using Rhino.Mocks;
    namespace Test.selftest
    {
        [TestFixture]
        class Framework_Test
        {
            [Test]
            public void ShouldCompileAndExecuteASimpleNUnitTest()
            {
                Assert.IsTrue(true);
            }
            [Test]
            public void ShouldVerifyRhinoMock()
            {
                ICloneable mock = MockRepository.GenerateMock<ICloneable>();
                mock.Expect(x => x.Clone()).Return(new Object()).Repeat.Times(1);
                mock.Clone();
                mock.VerifyAllExpectations();
            }
        }
    }
