    class Program
    {
        // Function used with 
        static int myFunction(H5GroupId id, string objectName, Object param)
        {
            Console.WriteLine("The object name is {0}", objectName);
            Console.WriteLine("The object parameter is {0}", param);
            return 0;
        }
        static void Main(string[] args)
        {
            try
            {
                // We will write and read an int array of this length.
                const int DATA_ARRAY_LENGTH = 12;
                // Rank is the number of dimensions of the data array.
                const int RANK = 1;
                // Create an HDF5 file.
                // The enumeration type H5F.CreateMode provides only the legal 
                // creation modes.  Missing H5Fcreate parameters are provided
                // with default values.
                H5FileId fileId = H5F.create("myCSharp.h5", 
                                             H5F.CreateMode.ACC_TRUNC);
  
                // Create a HDF5 group.  
                H5GroupId groupId = H5G.create(fileId, "/cSharpGroup", 0);
                H5GroupId subGroup = H5G.create(groupId, "mySubGroup", 0);   
             
                // Demonstrate getObjectInfo
                ObjectInfo info = H5G.getObjectInfo(fileId, "/cSharpGroup", true);
                Console.WriteLine("cSharpGroup header size is {0}", info.headerSize);
                Console.WriteLine("cSharpGroup nlinks is {0}", info.nHardLinks);
                Console.WriteLine("cSharpGroup fileno is {0} {1}", 
                     info.fileNumber[0], info.fileNumber[1]);
                Console.WriteLine("cSharpGroup objno is {0} {1}", 
                     info.objectNumber[0], info.objectNumber[1]);
                Console.WriteLine("cSharpGroup type is {0}", info.objectType);
                
         
                H5G.close(subGroup);
                // Prepare to create a data space for writing a 1-dimensional 
                // signed integer array.
                ulong[] dims = new ulong[RANK];
                dims[0] = DATA_ARRAY_LENGTH;
                // Put descending ramp data in an array so that we can
                // write it to the file.
                int[] dset_data = new int[DATA_ARRAY_LENGTH];
                for (int i = 0; i < DATA_ARRAY_LENGTH; i++)
                    dset_data[i] = DATA_ARRAY_LENGTH - i;
                // Create a data space to accommodate our 1-dimensional array.
                // The resulting H5DataSpaceId will be used to create the 
                // data set.
                H5DataSpaceId spaceId = H5S.create_simple(RANK, dims);
                // Create a copy of a standard data type.  We will use the 
                // resulting H5DataTypeId to create the data set.  We could
                // have  used the HST.H5Type data directly in the call to 
                // H5D.create, but this demonstrates the use of H5T.copy 
                // and the use of a H5DataTypeId in H5D.create.
                H5DataTypeId typeId = H5T.copy(H5T.H5Type.NATIVE_INT);
                // Find the size of the type
                uint typeSize = H5T.getSize(typeId);
                Console.WriteLine("typeSize is {0}", typeSize);
                // Set the order to big endian
                H5T.setOrder(typeId, H5T.Order.BE);
                // Set the order to little endian
                H5T.setOrder(typeId, H5T.Order.LE);
                // Create the data set.
                H5DataSetId dataSetId = H5D.create(fileId, "/csharpExample", 
                                                   typeId, spaceId);
                // Write the integer data to the data set.
                H5D.write(dataSetId, new H5DataTypeId(H5T.H5Type.NATIVE_INT),
                                  new H5Array<int>(dset_data));
                // If we were writing a single value it might look like this.
                //  int singleValue = 100;
                //  H5D.writeScalar(dataSetId, new H5DataTypeId(H5T.H5Type.NATIVE_INT),
                //     ref singleValue);
                // Create an integer array to receive the read data.
                int[] readDataBack = new int[DATA_ARRAY_LENGTH];
                // Read the integer data back from the data set
                H5D.read(dataSetId, new H5DataTypeId(H5T.H5Type.NATIVE_INT), 
                    new H5Array<int>(readDataBack));
                // Echo the data
                for(int i=0;i<DATA_ARRAY_LENGTH;i++)
                {
                   Console.WriteLine(readDataBack[i]);
                }  
                // Close all the open resources.
                H5D.close(dataSetId);
                // Reopen and close the data sets to show that we can.
                dataSetId = H5D.open(fileId, "/csharpExample");
                H5D.close(dataSetId);
                dataSetId = H5D.open(groupId, "/csharpExample");
                H5D.close(dataSetId);
                H5S.close(spaceId);
                H5T.close(typeId);
                H5G.close(groupId);
                //int x = 10;
                //H5T.enumInsert<int>(typeId, "myString", ref x);
                //H5G.close(groupId);
                H5GIterateDelegate myDelegate;
                myDelegate = myFunction;
                int x = 9;
                int index = H5G.iterate(fileId, "/cSharpGroup",
                    myDelegate, x, 0);
                // Reopen the group id to show that we can.
                groupId = H5G.open(fileId, "/cSharpGroup");
                H5G.close(groupId);
                H5F.close(fileId);
                // Reopen and reclose the file.
                H5FileId openId = H5F.open("myCSharp.h5", 
                                           H5F.OpenMode.ACC_RDONLY);
                H5F.close(openId);
            }
            // This catches all the HDF exception classes.  Because each call
            // generates unique exception, different exception can be handled
            // separately.  For example, to catch open errors we could have used
            // catch (H5FopenException openException).
            catch (HDFException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Processing complete!");
            Console.ReadLine();
        }
    }
}
