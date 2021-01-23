    Action<List<MeetingRoom>> _getRoomsCallback;
    IMeetingRoomService _meetingRoomServiceFake;
    private void SetupCallback()
    {
         Mock.Get(_meetingRoomServiceFake)
             .Setup(f => f.GetRooms(It.IsAny<Action<List<MeetingRoom>>>()))
             .Callback((Action<List<MeetingRoom>> cb) => _getRoomsCallback= cb);
    }
    [Setup]
    public void Setup()
    {
         _meetingRoomServiceFake = Mock.Of<IMeetingRoomService>();
         SetupCallback();
    }
    [Test]
    public void Test()
    {
          
          var viewModel = new SomeViewModel(_meetingRoomServiceFake)
          
          //in there the mock gets called and sets the _getRoomsCallback field.
          viewModel.GetRooms();
          var theRooms = new List<MeetingRoom>
                       {
                           new MeetingRoom(1, "some room"),
                           new MeetingRoom(2, "some other room"),
                       };
         //this will call whatever was passed as callback in your viewModel.
         _getRoomsCallback(theRooms);
    }
