    public class MyDirtyObject : IDirtyObject
    {
        // (note you can have get and set here even if the interface has only get)
        public bool IsDirty { get; set; }
        public IDirtyObject MyOtherDirtyObject;
        public List<IDirtyObject> MoreDirtyObjects;
        public void SetAllDirty(bool dirty)
        {
            IsDirty = dirty;
            if (MyOtherDirtyObject != null)
                MyOtherDirtyObject.SetAllDirty(dirty);
            if (MoreDirtyObjects != null)
                foreach (var obj in MoreDirtyObjects)
                    obj.SetAllDirty(dirty);
        }
    }
