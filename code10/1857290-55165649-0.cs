    public abstract class TestGeneratorProvider : IUnitTestGeneratorProvider
    {
        public CustomTestGeneratorProvider (CodeDomHelper codeDomHelper)
        {
            _unitTestGeneratorProvider = new 
            NUnit3TestGeneratorProvider(codeDomHelper);
            CodeDomHelper = codeDomHelper;
        }
        public UnitTestGeneratorTraits GetTraits()
        {
            return _unitTestGeneratorProvider.GetTraits();
        }
        public abstract void SetTestClass(TestClassGenerationContext generationContext, string featureTitle,
            string featureDescription)
        public void SetTestClassCategories(TestClassGenerationContext generationContext,
            IEnumerable<string> featureCategories)
        {
            _unitTestGeneratorProvider.SetTestClassCategories(generationContext, featureCategories);
        }
    }
