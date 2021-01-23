    class PropertyFieldAssociation
    {
        const byte LDARG_0 = 0x2;
        const byte LDARG_1 = 0x3;
        const byte STFLD = 0x7D;
        const byte LDFLD = 0x7B;
        const byte RET = 0x2A;
        
        static FieldInfo GetFieldFromGetMethod(MethodInfo getMethod)
        {
            if (getMethod == null) throw new ArgumentNullException("getMethod");
            
            var body = getMethod.GetMethodBody();
            if (body.LocalVariables.Count > 0) return null;
            var il = body.GetILAsByteArray();
            if (il.Length != 7) return null;
            var ilStream = new BinaryReader(new MemoryStream(il));
            
            if (ilStream.ReadByte() != LDARG_0) return null;
            if (ilStream.ReadByte() != LDFLD) return null;
            var fieldToken = ilStream.ReadInt32();
            var field = getMethod.Module.ResolveField(fieldToken);
            if (ilStream.ReadByte() != RET) return null;
            
            return field;
        }
        
        static FieldInfo GetFieldFromSetMethod(MethodInfo setMethod)
        {
            if (setMethod == null) throw new ArgumentNullException("setMethod");
            
            var body = setMethod.GetMethodBody();
            if (body.LocalVariables.Count > 0) return null;
            var il = body.GetILAsByteArray();
            if (il.Length != 8) return null;
            
            var ilStream = new BinaryReader(new MemoryStream(il));
            
            if (ilStream.ReadByte() != LDARG_0) return null;
            if (ilStream.ReadByte() != LDARG_1) return null;
            if (ilStream.ReadByte() != STFLD) return null;
            var fieldToken = ilStream.ReadInt32();
            var field = setMethod.Module.ResolveField(fieldToken);
            if (ilStream.ReadByte() != RET) return null;
            
            return field;
        }
        public static FieldInfo GetFieldFromProperty(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");
            
            var get = GetFieldFromGetMethod(property.GetGetMethod());
            var set = GetFieldFromSetMethod(property.GetSetMethod());
            
            if (get == set) return get;
            else return null;
        }
        Dictionary<PropertyInfo, FieldInfo> propertyToField = new Dictionary<PropertyInfo, FieldInfo>();
        Dictionary<FieldInfo, PropertyInfo> fieldToProperty = new Dictionary<FieldInfo, PropertyInfo>();
        
        public PropertyInfo GetProperty(FieldInfo field)
        {
            PropertyInfo result;
            fieldToProperty.TryGetValue(field, out result);
            return result;
        }
        
        public FieldInfo GetField(PropertyInfo property)
        {
            FieldInfo result;
            propertyToField.TryGetValue(property, out result);
            return result;
        }
        
        public PropertyFieldAssociation(Type t)
        {
            if (t == null) throw new ArgumentNullException("t");
            
            foreach(var property in t.GetProperties())
            {
                Add(property);
            }
        }
        
        void Add(PropertyInfo property)
        {
            if (property == null) throw new ArgumentNullException("property");
            
            var field = GetFieldFromProperty(property);
            if (field == null) return;
            propertyToField.Add(property, field);
            fieldToProperty.Add(field, property);
        }
    }
    class StringLengthAttribute : Attribute
    {
        public StringLengthAttribute(int l)
        {
        }
    }
    [Serializable]
    class Foo
    {
        [StringLength(15)]
        public string MyProperty { get; set; }
        
        string myField;
        [StringLength(20)]
        public string OtherProperty { get { return myField; } set { myField = value; } }
    }
