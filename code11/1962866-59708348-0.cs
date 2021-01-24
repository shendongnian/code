    abstract class CustomAttribute : Attribute {
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class MyTestAttribute : Attribute {}
    }
    
    [MyTest]
    class DerivedFromYourCustomAttribute : CustomAttribute {
    }
    
    [MyTest]
    class NotDerivedFromYourCustomAttribute {
    }
