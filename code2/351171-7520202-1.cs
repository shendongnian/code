    public interface Bob
    { void DoThings(IEnumrable<int> list); }
    public class Joe
    {
        private readonly Bob bob;
        public Joe(Bob bob)
        { this.bob = bob; }
        public void MethodThatShouldCallDoThingWith10()
        { bob.DoThings(new List<int>{1,2,3,4,5,6,7,8,9,10}); }
    }
