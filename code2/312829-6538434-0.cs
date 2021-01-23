            // Get the AClass type to access its metadata.
            Type clsType = typeof(AClass);
            // Get the type information for Win32CallMethod.
            MethodInfo mInfo = clsType.GetMethod("Win32CallMethod");
            if (mInfo != null)
            {
                // Iterate through all the attributes of the method.
                foreach(Attribute attr in
                    Attribute.GetCustomAttributes(mInfo)) {
                    // Check for the Obsolete attribute.
                    if (attr.GetType() == typeof(ObsoleteAttribute))
                    {
                        Console.WriteLine("Method {0} is obsolete. " +
                            "The message is:",
                            mInfo.Name);
                        Console.WriteLine("  \"{0}\"",
                            ((ObsoleteAttribute)attr).Message);
                    }
                    // Check for the Unmanaged attribute.
                    else if (attr.GetType() == typeof(UnmanagedAttribute))
                    {
                        Console.WriteLine(
                            "This method calls unmanaged code.");
                        Console.WriteLine(
                            String.Format("The Unmanaged attribute type is {0}.",
                                          ((UnmanagedAttribute)attr).Win32Type));
                        AClass myCls = new AClass();
                        myCls.Win32CallMethod();
                    }
                }
            }
