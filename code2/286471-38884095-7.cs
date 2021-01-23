    // The class that does the marshaling. Making it generic is not required, but
    // will make it easier to use the same custom marshaler for multiple array types.
    public class ArrayMarshaler<T> : ICustomMarshaler
    {
        // All custom marshalers require a static factory method with this signature.
        public static ICustomMarshaler GetInstance (String cookie)
        {
            return new ArrayMarshaler<T>();
        }
        // This is the function that builds the managed type - in this case, the managed
        // array - from a pointer. You can just return null here if only sending the 
        // array as an in-parameter.
        public Object MarshalNativeToManaged (IntPtr pNativeData)
        {
            // First, sanity check...
            if (IntPtr.Zero == pNativeData) return null;
            // Start by reading the size of the array ("Length" from your ABS_DATA struct)
            int length = Marshal.ReadInt32(pNativeData);
            // Create the managed array that will be returned
            T[] array = new T[length];
            // For efficiency, only compute the element size once
            int elSiz = Marshal.SizeOf<T>();
            // Populate the array
            for (int i = 0; i < length; i++)
            {
                array[i] = Marshal.PtrToStructure<T>(pNativeData + sizeof(int) + (elSiz * i));
            }
            // Alternate method, for arrays of primitive types only:
            // Marshal.Copy(pNativeData + sizeof(int), array, 0, length);
            return array;
        }
        // This is the function that marshals your managed array to unmanaged memory.
        // If you only ever marshal the array out, not in, you can return IntPtr.Zero
        public IntPtr MarshalManagedToNative (Object ManagedObject)
        {
            if (null == ManagedObject) return IntPtr.Zero;
            T[] array = (T[])ManagedObj;
            int elSiz = Marshal.SizeOf<T>();
            // Get the total size of unmanaged memory that is needed (length + elements)
            int size = sizeof(int) + (elSiz * array.Length);
            // Allocate unmanaged space. For COM, use Marshal.AllocCoTaskMem instead.
            IntPtr ptr = Marshal.AllocHGlobal(size);
            // Write the "Length" field first
            Marshal.WriteInt32(ptr, array.Length);
            // Write the array data
            for (int i = 0; i < array.Length; i++)
            {   // Newly-allocated space has no existing object, so the last param is false
                Marshal.StructureToPtr<T>(array[i], ptr + sizeof(int) + (elSiz * i), false);
            }
            // If you're only using arrays of primitive types, you could use this instead:
            //Marshal.Copy(array, 0, ptr + sizeof(int), array.Length);
            return ptr;
        }
        // This function is called after completing the call that required marshaling to
        // unmanaged memory. You should use it to free any unmanaged memory you allocated.
        // If you never consume unmanaged memory or other resources, do nothing here.
        public void CleanUpNativeData (IntPtr pNativeData)
        {
            // Free the unmanaged memory. Use Marshal.FreeCoTaskMem if using COM.
            Marshal.FreeHGlobal(pNativeData);
        }
        // If, after marshaling from unmanaged to managed, you have anything that needs
        // to be taken care of when you're done with the object, put it here. Garbage 
        // collection will free the managed object, so I've left this function empty.
        public void CleanUpManagedData (Object ManagedObj)
        { }
        // This function is a lie. It looks like it should be impossible to get the right 
        // value - the whole problem is that the size of each array is variable! 
        // - but in practice the runtime doesn't rely on this and may not even call it.
        // The MSDN example returns -1; I'll try to be a little more realistic.
        public int GetNativeDataSize ()
        {
            return sizeof(int) + Marshal.SizeOf<T>();
        }
    }
