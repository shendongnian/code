TestArrayItem.cs
    // ----------------------------------------------
    //      rights lavished upon all with love
    //         see 'license/unlicense.txt'
    //   ♥ 2011, shelley butterfly - public domain
    // ----------------------------------------------
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace MemStorageDemo
    {
    	public unsafe class TestArrayItem
    	{
    		public static MemoryStringArray s_MemoryArrayStore = new MemoryStringArray();
    
    		public static int TestArrayItemSize_bytes =
    			sizeof(double) * 2
    			+ sizeof(int)
    			+ sizeof(int);
    
    		// hard-coding here; this is another place that things could be a little more generic if you wanted and if 
    		// performance permitted; for instance, creating a dictionary of offsets based on index.  also, perhaps
    		// a dictionary with key strings to allow indexing using field names of the object.
    		private enum EFieldOffset
    		{
    			DoubleTheFirstOffset       =  0,
    			DoubleTheSecondOffset      =  8,
    			IntTheFirstOffset          = 16,
    			StringTheFirstHandleOffset = 20
    		}
    
    		private MemoryArrayItem myMemoryArrayItem;
    		private MemoryStringArray myStringStore;
    
    		// constructor that uses the static string array store
    		public TestArrayItem(MemoryArrayItem parMemoryArrayItem) :
    			this(parMemoryArrayItem, s_MemoryArrayStore)
    		{
    		}
    
    		// constructor for getting the item at its memory block without any initialization (e.g. existing item)
    		public TestArrayItem(MemoryArrayItem parMemoryArrayItem, MemoryStringArray parStringStore)
    		{
    			myMemoryArrayItem = parMemoryArrayItem;
    			myStringStore = parStringStore;
    		}
    
    		// constructor for geting the item at its memory block and initializing it (e.g. adding new items)
    		public TestArrayItem(MemoryArrayItem parMemoryArrayItem, double parDoubleTheFirst, double parDoubleTheSecond, int parIntTheFirst, string parStringTheFirst)
    		{
    			myMemoryArrayItem = parMemoryArrayItem;
    
    			DoubleTheFirst = parDoubleTheFirst;
    			DoubleTheSecond = parDoubleTheSecond;
    			IntTheFirst = parIntTheFirst;
    			StringTheFirst = parStringTheFirst;
    		}
    
    		// if you end up in a situation where the compiler isn't giving you equivalent performance to just doing
    		// the array math directly in the properties, you could always just do the math directly in the properties.
    		//
    		// it reads much cleaner the way i have it set up, and there's a lot less code duplication, so without 
    		// actually determining empirically that i needed to do so, i would stick with the function calls.
    		private IntPtr GetPointerAtOffset(EFieldOffset parFieldOffset)
    			{ return myMemoryArrayItem.ObjectPointer + (int)parFieldOffset; }
    
    		private double* DoubleTheFirstPtr 
    			{ get { return (double*)GetPointerAtOffset(EFieldOffset.DoubleTheFirstOffset); } }
    		public double DoubleTheFirst
    		{
    			get
    			{
    				return *DoubleTheFirstPtr;
    			}
    
    			set
    			{
    				*DoubleTheFirstPtr = value;
    			}
    		}
    
    		private double* DoubleTheSecondPtr
    			{ get { return (double*)GetPointerAtOffset(EFieldOffset.DoubleTheSecondOffset); } }
    		public double DoubleTheSecond
    		{
    			get
    			{
    				return *DoubleTheSecondPtr;
    			}
    			set
    			{
    				*DoubleTheSecondPtr = value;
    			}
    		}
    
    		// ahh wishing for a preprocessor about now
    		private int* IntTheFirstPtr
    			{ get { return (int*)GetPointerAtOffset(EFieldOffset.IntTheFirstOffset); } }
    		public int IntTheFirst
    		{
    			get
    			{
    				return *IntTheFirstPtr;
    			}
    			set
    			{
    				*IntTheFirstPtr = value;
    			}
    		}
    
    		// okay since we're using the StringArray backing store in the example, we just need to get the
    		// pointer stored in our blocks, and then copy the data from that address 
    		private int* StringTheFirstHandlePtr 
    			{ get { return (int*)GetPointerAtOffset(EFieldOffset.StringTheFirstHandleOffset); } }
    		public string StringTheFirst
    		{
    			get
    			{
    				return myStringStore.GetString(*StringTheFirstHandlePtr);
    			}
    			set
    			{
    				myStringStore.ModifyString(*StringTheFirstHandlePtr, value);
    			}
    		}
    
    		public void CreateStringTheFirst(string WithValue)
    		{
    			*StringTheFirstHandlePtr = myStringStore.AddString(WithValue);
    		}
    
    		public override string ToString()
    		{
    			return string.Format("{0:X8}: {{ {1:0.000}, {2:0.000}, {3}, {4} }} {5:X8}", (int)DoubleTheFirstPtr, DoubleTheFirst, DoubleTheSecond, IntTheFirst, StringTheFirst, (int)myMemoryArrayItem.ObjectPointer);
    		}
    	}
    }
      
