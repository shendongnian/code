    System.Reflection.FieldInfo[] fieldsInfos = typeof(NullWeAre).GetFields();
    
            foreach (System.Reflection.FieldInfo fi in fieldsInfos)
            {
                if (fi.FieldType.IsGenericType
                    && fi.FieldType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                {
                    // We are dealing with a generic type that is nullable
                    Console.WriteLine("Name: {0}, Type: {1}", fi.Name, Nullable.GetUnderlyingType(fi.FieldType));
                }
        
        }
