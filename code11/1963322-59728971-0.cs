private class MyTestActor : MyActor
{
   public string Result {get; set;} = "ok";
   public override Task<string> DoThat() { return Task.FromResult(Result); }
}
Your test code would be like this:
private MyActor CreateActor(ActorId id) 
{
  Func<ActorService, ActorId, ActorBase> factory = (service, actorId) => new MyTestActor(service, id);
  var svc = MockActorServiceFactory.CreateActorServiceForActor<MyTestActor>(factory);
  var actor = svc.Activate(id);
  return actor;
}
Or, you could move the logic from `DoThat` into a separate class with an interface, use dependency injection and pass in different implementations for test / real runs.
