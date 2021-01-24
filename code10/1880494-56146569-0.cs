    try
        {
            // Get the type of MyClass1.
            Type myType = typeof(MyClass1);
            // Get the members associated with MyClass1.
            MemberInfo[] myMembers = myType.GetMembers();
            // Display the attributes for each of the members of MyClass1.
            for(int i = 0; i < myMembers.Length; i++)
            {
                Object[] myAttributes = myMembers[i].GetCustomAttributes(true);
                if(myAttributes.Length > 0)
                {
                    Console.WriteLine("\nThe attributes for the member {0} are: \n", myMembers[i]);
                    for(int j = 0; j < myAttributes.Length; j++)
                        Console.WriteLine("The type of the attribute is {0}.", myAttributes[j]);
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("An exception occurred: {0}", e.Message);
        }
