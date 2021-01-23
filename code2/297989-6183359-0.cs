    public class StableFiniteSequenceCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new StableFiniteSequenceRelay());
        }
    }
