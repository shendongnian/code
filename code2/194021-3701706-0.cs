    class NullPerson : Person {
      public override Head Head { get { return new NullHead(); }
    }
    class NullHead : Head {
      public override Nose Nose { get { return new NullNose(); }
    }
    class NullNose : Nose {
      public override void Sniff() { /* no-op */ }
    }
