    public interface IMyNumeric
    {
      //perhaps a bit dodgy, but hey-ho
      object Value { get; }
      INumeric Add(INumeric other);
      INumeric Substract(INumeric other);
      INumeric Multiply(INumeric other);
      INumeric Divide(INumeric other);
    }
