    public class CustomTestGeneratorProvider : TestGeneratorProvider
    {
        public override void SetTestClass(TestClassGenerationContext generationContext, string featureTitle,
        string featureDescription)
        {
            _unitTestGeneratorProvider.SetTestClass(generationContext, featureTitle, featureDescription);
        }
    }
