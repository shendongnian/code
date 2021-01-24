    public class ConditionGroupService
    {
        public void When(TriggerConditionMatched @event)
        {
            //re-hydrate your condition group aggregate root from event store
            var conditionGroup = getConditionGroup(@event.Condition.GroupId);
            
            if(conditionGroup is not null)
                conditionGroup.MatchTriggerToConditionGroup();
        }
    }
    public class ConditionGroup : AggregateRoot
    {
        ...
        public void MatchTriggerToConditionGroup()
        {
            ...
            //do some check here, your business logic
            //raise the next event
            publish(new TriggerConditionGroupMatched(this));
        }
    }
    //this is your TriggerConditionGroupMatched event
    public class TriggerConditionGroupMatched
    {
        public readonly ConditionGroup ConditionGroup;
        public TriggerConditionGroupMatched(ConditionGroup conditionGroup)
        {
            ConditionGroup = conditionGroup;
        }
    }
