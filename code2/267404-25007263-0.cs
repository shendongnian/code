    using System.Collections.Generic
    using System.Reflection
    using System
    private List<TBase> GetMockShapes<TBase>()
         where TBase : Shape
    {
        Type mockType = getAppropriateMockType<TBase>();
        // Sanity check -- if this fails, bad things might happen.
        Assert(typeof(TBase).IsAssignableFrom(mockType));
        List<TBase> mockShapes = new List<TBase>();
        // Find MockShapeFactory.CreateMockShape() method
        MethodInfo shapeCreator = typeof(MockShapeFactory).GetMethod("CreateMockShape");
        // Convert to CreateMockShape<mockType>() method
        shapeCreator = shapeCreator.MakeGenericMethod(new Type[] { mockType });
        for (int i = 0; i < 5; i++)
        {
            // Invoke the method to get a generic object
            // The object to invoke on is null because the method is static
            // The parameter array is null because the method expects no parameters
            object mockShape = shapeCreator.Invoke(null, null);
            mockShapes.GetType()                 // Get the type of mockShapes
                .GetMethod("Add")                // Get its Add method
                .Invoke(                         // Invoke the method
                    mockShapes,                  // on mockShapes list
                    new object[] { mockShape }); // with mockShape as argument.
        }
        return mockShapes;
    }
