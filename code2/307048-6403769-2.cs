    class A
    {
        public string Code { get; set; }
        public virtual void Copy(A other)
        {
            this.Code = other.Code;
        }
    }
    class B : A
    {
        DateTime Start { get; set; }
        DateTime? End { get; set; }
        public override virtual void Copy(B other)
        {
            base.Copy(other);
            this.Start = other.Start;
            this.End = other.End;
        }
    }
