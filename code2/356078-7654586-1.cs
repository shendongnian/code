    public static class MaybeLocalExtensions
    {
        public static Maybe<T> OnExceptionNoValue<T>(this Maybe<T> maybe)
        {
            return maybe.Exception != null ? Maybe<T>.NoValue : maybe;
        }
    }
    // Sample Use Case:
    var maybe = Maybe.Defer(() => (string)expando.NonExistingProperty).Catch()
        .OnExceptionNoValue();
