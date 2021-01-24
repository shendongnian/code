    public class Condition : AggregateRoot
    {
        ...
        public void MatchTrigger()
        {
            //your business logic here
            ...
            //we know trigger value matched one condition, so raise the next event
            publish(new TriggerConditionMatched(this));
        }
    }
    //this is your TriggerConditionMatched event
    public class TriggerConditionMatched
    {
        public readonly Condition Condition;
        public TriggerConditionMatched(Condition condition)
        {
            Condition = condition;
        }
    }
