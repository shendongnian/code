    public class When_registering_an_domain_event : BaseTestFixture<PreProcessor>
    {
        /* ... */
        
        protected override void When()
        {
            SubjectUnderTest.RegisterForPreProcessing<ClientMovedEvent>();
            SubjectUnderTest.Process();
        }
        [Then]
        public void Then_the_event_processors_for_client_moved_event_will_be_registered()
        {
            IEnumerable<EventProcessor> eventProcessors;
            EventProcessorCache.TryGetEventProcessorsFor(typeof(ClientMovedEvent), out eventProcessors);
            eventProcessors.Count().WillBe(1);
        }
    }
