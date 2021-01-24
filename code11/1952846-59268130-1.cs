    // Class with Fields
    public class MyObjectCollection
    {
        public MyObject Object001;
        public MyObject ObjTwo;
    }
    public class Logic
    {
        // Init logic
        public void Initialise(object controls)
        {
            Type targType = typeof(MyObject);
            var t = controls.GetType();
            // iterate all fields of type MyObject
            foreach(var fi in t.GetFields().Where(f=>f.FieldType == targType))
            {
                // initialise as required.
                var o = new MyObject();
                o.Name = fi.Name;
                fi.SetValue(controls, o);
            }
        }
    }
If the field name is not enough for the object name you could use Attributes on the fields to direct initialisation.
