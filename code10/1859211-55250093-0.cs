    class Lion : I<Lion> 
    {
      public Lion Get() => this;
    }
    class TaxPolicyFactory : I<TaxPolicy>
    {
      public TaxPolicy Get() => new TaxPolicy();
    }
    class Door: I<Doorknob>
    {
      public Doorknob Get() => this.doorknob;
      ...
    }
