    [TestFixture]
    public class Tests
    {
        [Test]
        public void DoWork_DoesX_And_DoesY()
        {
            var kernel = new Ninject.MockingKernel.RhinoMock.RhinoMocksMockingKernel();
            var dep1 = MockRepository.GenerateMock<IFoo>();
            var dep2 = MockRepository.GenerateMock<IFoo>();
            kernel.Bind<IFoo>().ToMethod((ctx) => dep1).When((ctx) => ctx.Target.Name.StartsWith("dep1"));
            kernel.Bind<IFoo>().ToMethod((ctx) => dep2).When((ctx) => ctx.Target.Name.StartsWith("dep2"));
                        
            var sut = kernel.Get<SubjectUnderTest>();
            dep1.Expect(it => it.DoX());
            dep2.Expect(it => it.DoY());
            sut.DoWork();
            dep1.VerifyAllExpectations();
            dep2.VerifyAllExpectations();
        }
    }
