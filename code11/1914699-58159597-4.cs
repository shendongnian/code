    public class WatchDogService
    {
        public void When(TriggerConditionGroupMatched @event)
        {
            //re-hydrate your Watch Dog aggregate root from event store
            var watchDog = getWatchDog(@event.ConditionGroup.WatchDogId);
            
            if(watchDog is not null)
                watchDog.Bark();
        }
    }
    public class WatchDog : AggregateRoot
    {
        ...
        public void Bark()
        {
            ...
            this.ShouldBark = true;
            //you should raise your next event
            publish(nextEvent);
        }
    }
