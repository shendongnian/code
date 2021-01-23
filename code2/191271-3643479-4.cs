    class TypeWithEvents
    {
        // If I understand you correctly, you want the
        // TypeOfProperty class to automatically raise
        // an event on a TypeWithEvents object when a
        // variable of type TypeOfProperty gets
        // ASSIGNED to a new value?
        //
        // THAT is completely impossible, as assigning
        // a variable to a new object/value is very
        // different from calling a method on that
        // object.
        public TypeOfProperty Property { get; set; }
    }
