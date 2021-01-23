    namespace SomeNamespace {
        public interface ICommon {
            int Foo {get;}
        }
    }
    namespace Webservice1Namespace {
        partial class Webservice1 : ICommon {  }
    }
    namespace Webservice2Namespace {
        partial class Webservice2 : ICommon {  }
    }
    // note we didn't add a .Foo implementation - that comes from the
    // *other* half of the partial classes, as per the .designer.cs
