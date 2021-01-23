    class Foo
    {
        // move the common properties to the base class
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public override bool Equals(object obj)
        {
            Foo objfoo = obj as Foo;
            return 
                objfoo != null
                // require objects being compared to be of
                // the same derived type (optionally)
                && this.GetType() == obj.GetType()
                && objfoo.Number1 == this.Number1
                && objfoo.Number2 == this.Number2;
        }
        public override int GetHashCode()
        {
            // xor the hash codes of the elements used to evaluate
            // equality
            return Number1.GetHashCode() ^ Number2.GetHashCode();
        }
    }
    class A : Foo, IEquatable<A>
    {
        // A has no properties Foo does not.  Simply implement
        // IEquatable<A>
        public bool Equals(A other)
        {
            return this.Equals(other);
        }
        // can optionally override Equals(object) and GetHashCode()
        // to call base methods here
    }
    class B : Foo, IEquatable<B>
    {
        // Add property Number3 to B
        public int Number3 { get; set; }
        public bool Equals(B other)
        {
            // base.Equals(other) evaluates Number1 and Number2
            return base.Equals(other)
                && this.Number3 == other.Number3;
        }
        public override int GetHashCode()
        {
            // include Number3 in the hashcode, since it is used
            // to evaluate equality
            return base.GetHashCode() ^ Number3.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as B);
        }
    }
