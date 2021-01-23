    [Behaviors]
    public class DeferredExecutionProcessor
    {
        It should_not_have_enumerated_the_original_samples = () =>
        {
            _.Original.DidNotReceive().GetEnumerator();
            ((IEnumerable)_.Original).DidNotReceive().GetEnumerator();
        };
        protected static Context _; 
    }
