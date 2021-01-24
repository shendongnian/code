    public class FooDTO : StatefulObject
    {
        public FooDTO(string prop1, string prop2)
        {
            // Set the properties...
            Prop1 = prop1;
            // Ensure IsDirty is false;
            Reset(); 
        }
    }
