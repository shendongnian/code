    private void SetPropertyGrid() 
    { 
         PropertyDescriptor descriptor = TypeDescriptor.GetProperties(typeof(Student))["Address"];
         ReadOnlyAttribute attrib = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
         FieldInfo isReadOnly = attrib.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);
            isReadOnly.SetValue(attrib,true);
         propertyGrid1.SelectedObject = new Student();  
    }
