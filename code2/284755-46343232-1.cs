    public class Class1Tests : IDisposable
    {
        [Fact]
        public void ThrowMe_NoMocking_Throws()
        {
            Should.Throw<Exception>(() => LegacyStaticClass.ThrowMe<Exception>());
        }
        [Fact]
        public void ThrowMe_EmptyMocking_DoesNotThrow()
        {
            LegacyStaticClass.ThrowMeDelegate = input => { };
            LegacyStaticClass.ThrowMe<Exception>();
            true.ShouldBeTrue();
        }
        [Fact]
        public void Sum_NoMocking_AddsValues()
        {
            LegacyStaticClass.Sum(5, 6).ShouldBe(11);
        }
        [Fact]
        public void Sum_MockingReturnValue_ReturnsMockedValue()
        {
            LegacyStaticClass.SumDelegate = (a, b) => 6;
            LegacyStaticClass.Sum(5, 6).ShouldBe(6);
        }
        public void Dispose()
        {
            LegacyStaticClass.ResetDelegates();
        }
    }
