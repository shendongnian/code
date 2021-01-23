    class A
    {
        public string Code { get; set; }
        public virtual void ShallowCopy(A other)
        {
            this.Code = other.Code;
        }
    }
    class B : A
    {
        DateTime Start { get; set; }
        DateTime? End { get; set; }
        public override virtual void ShallowCopy(B other)
        {
            base.ShallowCopy(other);
            this.Start = other.Start;
            this.End = other.End;
        }
    }
