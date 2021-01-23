    abstract class BaseImmutable<T> {
        // ... 
        public T ModifiedButNotReally() { // ... }
    }
    class DerivedImmutable : BaseImmutable<DerivedImmutable> { // ... }
