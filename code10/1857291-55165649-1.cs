    public class CustomTestGeneratorProvider : TestGeneratorProvider
    {
        public override void SetTestClass(TestClassGenerationContext generationContext, string featureTitle,
        string featureDescription)
        {
            _unitTestGeneratorProvider.SetTestClass(generationContext, featureTitle, featureDescription);
            generationContext.Namespace.Imports.Add(new CodeNamespaceImport("Com.MyOrg.Custom.Core.Feature"));
            generationContext.TestClass.BaseTypes.Add("MyOrgTest");
         }
    }
