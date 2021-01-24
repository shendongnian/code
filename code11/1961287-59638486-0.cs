    //...
    [Fact]
    public async Task CreateEventSuccess_should_return_the_object_created() {
        //Arrange
        
        //Making sure DTO can pass validation.
        var dataEventDto = new EventDto();
        dataEventDto.Title = "this is a test for add event";
        dataEventDto.Description = "this is a description for the add event";
        dataEventDto.Venue = "this is the street";
        dataEventDto.Date = DateTime.Now;
        dataEventDto.Booking = true;
        dataEventDto.TypeEvent = EventType.Presential;
        dataEventDto.State = EventState.Published;
        dataEventDto.CancellationReason = "this is a test of cancellation event";
        dataEventDto.Url = "this is a url";
        //mocked repository to verify expected behavior.
        IEventRepository eventRepository = A.Fake<IEventRepository>();
        A.CallTo(() => eventRepository.Add(A<Event>._)).Returns(Task.FromResult(new Event()));
        
        //Assuming an actual mapper is being used.
        var subject = new EventService(eventRepository, this.mapper);
        //Act
        await subject.Add(dataEventDto);
        //Assert
        A.CallTo(() => eventRepository.Add(A<Event>._)).MustHaveHappened();
    }
