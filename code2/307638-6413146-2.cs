     // Determines whether the given type is supported for materialization
        private void CheckInitializerType(Type type)
        {
            // nominal types are not supported
            TypeUsage typeUsage;
            if (_funcletizer.RootContext.Perspective.TryGetType(type, out typeUsage))
            {
                  BuiltInTypeKind typeKind = typeUsage.EdmType.BuiltInTypeKind;
                  if (BuiltInTypeKind.EntityType == typeKind ||
                      BuiltInTypeKind.ComplexType == typeKind)
                  {
                      throw EntityUtil.NotSupported(System.Data.Entity.Strings.ELinq_UnsupportedNominalType(
                                typeUsage.EdmType.FullName));
                  }
            }
          
            // types implementing IEnumerable are not supported
            if (TypeSystem.IsSequenceType(type))
            {
                 throw EntityUtil.NotSupported(System.Data.Entity.Strings.ELinq_UnsupportedEnumerableType(
                            DescribeClrType(type)));
            }
       }
