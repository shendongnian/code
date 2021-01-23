    class GenericTag<T>
    {
        public GenericTag(T payload)
        {
            this.Payload = payload;
        }
        public T Payload { set; get; }
    }
    // OK: no conversion required.
    var tag2 = new GenericTag<Int64>(Int64.MaxValue);
    // OK: implicit conversion takes place.
    var tag1 = new GenericTag<Int64>(Int32.MaxValue);
    // Compile error: cannot convert from long to int.
    var tag4 = new GenericTag<Int32>(Int64.MaxValue);
    // Compile error: cannot convert from string to long.
    var tag3 = new GenericTag<Int64>("foo");
