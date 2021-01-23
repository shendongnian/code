    // Summary:
        //     Creates an instance of the specified type using the constructor that best
        //     matches the specified parameters.
        //
        // Parameters:
        //   type:
        //     The type of object to create.
        //
        //   args:
        //     An array of arguments that match in number, order, and type the parameters
        //     of the constructor to invoke. If args is an empty array or null, the constructor
        //     that takes no parameters (the default constructor) is invoked.
        //
        // Returns:
        //     A reference to the newly created object.
        //
        // Exceptions:
        //   System.ArgumentNullException:
        //     type is null.
        //
        //   System.ArgumentException:
        //     type is not a RuntimeType. -or-type is an open generic type (that is, the
        //     System.Type.ContainsGenericParameters property returns true).
        //
        //   System.NotSupportedException:
        //     type cannot be a System.Reflection.Emit.TypeBuilder.-or- Creation of System.TypedReference,
        //     System.ArgIterator, System.Void, and System.RuntimeArgumentHandle types,
        //     or arrays of those types, is not supported. -or-The constructor that best
        //     matches args has varargs arguments.
        //
        //   System.Reflection.TargetInvocationException:
        //     The constructor being called throws an exception.
        //
        //   System.MethodAccessException:
        //     The caller does not have permission to call this constructor.
        //
        //   System.MemberAccessException:
        //     Cannot create an instance of an abstract class, or this member was invoked
        //     with a late-binding mechanism.
        //
        //   System.Runtime.InteropServices.InvalidComObjectException:
        //     The COM type was not obtained through Overload:System.Type.GetTypeFromProgID
        //     or Overload:System.Type.GetTypeFromCLSID.
        //
        //   System.MissingMethodException:
        //     No matching public constructor was found.
        //
        //   System.Runtime.InteropServices.COMException:
        //     type is a COM object but the class identifier used to obtain the type is
        //     invalid, or the identified class is not registered.
        //
        //   System.TypeLoadException:
        //     type is not a valid type.
        public static object CreateInstance(Type type, params object[] args);
