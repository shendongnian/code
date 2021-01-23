    using System.Collections.Generic;
    using System.Reflection;
    using System;
    private List<TBase> GetMockShapes<TBase>()
         where TBase : Shape
    {
        Type TMock = getAppropriateMockType<TBase>();
        // Sanity check -- if this fails, bad things might happen.
        Assert(typeof(TBase).IsAssignableFrom(TMock));
        List<TBase> mockShapes = new List<TBase>();
        // Find MockShapeFactory.CreateMockShape() method
        MethodInfo shapeCreator = typeof(MockShapeFactory).GetMethod("CreateMockShape");
        // Convert to CreateMockShape<mockType>() method
        shapeCreator = shapeCreator.MakeGenericMethod(new Type[] { TMock });
        for (int i = 0; i < 5; i++)
        {
            // Invoke the method to get a generic object
            // The object to invoke on is null because the method is static
            // The parameter array is null because the method expects no parameters
            object mockShape = shapeCreator.Invoke(null, null);
            //
            // Changes start here
            //
            // Static cast the mock shape to the type it's impersonating
            TBase mockBase = (TBase)mockShape;
            // Now this works because typeof(mockBase) is known at compile time.
            mockShapes.Add(mockBase);
        }
        return mockShapes;
    }
