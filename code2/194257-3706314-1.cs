    interface IDirtyObject {
        bool IsDirty { get; set; }
    }
    class ExampleDirtyObject : IDirtyObject {
        public bool IsDirty { get; set; }
    }
    foreach (IDirtyObject obj in myobjects)
        obj.IsDirty = false;
