    public interface IMessage { }
    public interface IEvent : IMessage { }
    public class DogBarkedEvent : IEvent
    {
        public string NameOfDog { get; set; }
        public int Times { get; set; }
    }
    class DontAskWrapper
    {
        public IMessage Message { get; set; }
    }
    [Test]
    public void RoundTripAnUnknownMessage()
    {
        IMessage msg = new DogBarkedEvent
        {
            NameOfDog = "Woofy",
            Times = 5
        }, copy;
        var model = TypeModel.Create();
        model.Add(typeof (DogBarkedEvent), false).Add("NameOfDog", "Times");
        model.Add(typeof (IMessage), false).AddSubType(1, typeof (DogBarkedEvent));
        model.Add(typeof (DontAskWrapper), false).Add("Message");
        using (var ms = new MemoryStream())
        {
            var tmp = new DontAskWrapper { Message = msg };
            model.Serialize(ms, tmp);
            ms.Position = 0;
            string hex = Program.GetByteString(ms.ToArray());
            Debug.WriteLine(hex);
            var wrapper = (DontAskWrapper)model.Deserialize(ms, null, typeof(DontAskWrapper));
            copy = wrapper.Message;
        }
        // check the data is all there
        Assert.IsInstanceOfType(typeof(DogBarkedEvent), copy);
        var typed = (DogBarkedEvent)copy;
        var orig = (DogBarkedEvent)msg;
        Assert.AreEqual(orig.Times, typed.Times);
        Assert.AreEqual(orig.NameOfDog, typed.NameOfDog);
    }
