    //...
    [Fact]
    public async Task CreateEventSuccess_should_return_the_object_created() {
        //Arrange
        
        //Making sure DTO can pass validation.
        var expected = new EventDto();
        expected.Title = "this is a test for add event";
        expected.Description = "this is a description for the add event";
        expected.Venue = "this is the street";
        expected.Date = DateTime.Now;
        expected.Booking = true;
        expected.TypeEvent = EventType.Presential;
        expected.State = EventState.Published;
        expected.CancellationReason = "this is a test of cancellation event";
        expected.Url = "this is a url";
        //mocked repository to verify expected behavior.
        IEventRepository eventRepository = A.Fake<IEventRepository>();
        Event passedEvent = null;
        A.CallTo(() => eventRepository.Add(A<Event>._))
            .Invokes((Event arg) => passedEvent = arg)
            .Returns(passedEvent);
        
        //Assuming an actual mapper is being used.
        var subject = new EventService(eventRepository, this.mapper);
        //Act
        EventDto actual = await subject.Add(expected);
        //Assert
        A.CallTo(() => eventRepository.Add(A<Event>._)).MustHaveHappened();
        
        //expected and actual should be equivalent, so that could also be checked
        
    }
