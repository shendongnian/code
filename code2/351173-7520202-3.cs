    public interface Bob
    { void DoThings(IEnumrable<int> list); }
    public class Joe
    {
        private readonly Bob bob;
        public Joe(Bob bob)
        { this.bob = bob; }
        public void MethodThatShouldCallDoThingWith10()
        { 
              var values = Enumerable.Range(1, 100).Where(x => x > 0 && x < 11);
              bob.DoThings(values); 
        }
    }
