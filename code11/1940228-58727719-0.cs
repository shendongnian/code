  class MyReference : ICloneable
  {
    public string Id { get; set; }
    public string FullName { get; set; }
    public object Clone()
    {
      return new MyReference()
      {
        Id = this.Id,
        FullName = this.FullName
      };
    }
  }
Now when clicking the button you can use Theodors `Task.Delay` method and give it a copy of your object:
    public void OnButtonClick()
    {
      //Here we now copy the complete object not just the reference to it
      var localCopyOfTheReference = (MyReference)someReference.Clone();
      var fireAndForget = Task.Run(async () =>
      {
        await Task.Delay(30000);
        Send(localCopyOfTheReference);
      });
    }
