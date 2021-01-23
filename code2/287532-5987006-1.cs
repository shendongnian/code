          			cmdHwnd = child;
        		}
      		}
		}
		
		/// <summary>
    	/// Returns a list of child windows
    	/// </summary>
    	/// <param name="parent">Parent of the windows to return</param>
    	/// <returns>List of child windows</returns>
    	public static List<IntPtr> GetChildWindows(IntPtr parent)
    	{
    		List<IntPtr> result = new List<IntPtr>();
      		GCHandle listHandle = GCHandle.Alloc(result);
      		try
      		{
        		EnumWindowProc childProc = new EnumWindowProc(EnumWindow);
        		EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
      		}
      		finally
      		{
        		if (listHandle.IsAllocated)
          		listHandle.Free();
      		}
      		return result;
    	}
    	/// <summary>
    	/// Callback method to be used when enumerating windows.
    	/// </summary>
    	/// <param name="handle">Handle of the next window</param>
    	/// <param name="pointer">Pointer to a GCHandle that holds a reference to the list to fill</param>
    	/// <returns>True to continue the enumeration, false to bail</returns>
    
    	private static bool EnumWindow(IntPtr handle, IntPtr pointer)
    	{
      		GCHandle gch = GCHandle.FromIntPtr(pointer);
      		List<IntPtr> list = gch.Target as List<IntPtr>;
      		if (list == null)
      		{
        		throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
      		}
      		list.Add(handle);
      		// You can modify this to check to see if you want to cancel the operation, then return a null here
      		return true;
    	}
    	/// <summary>
    	/// Delegate for the EnumChildWindows method
    	/// </summary>
    	/// <param name="hWnd">Window handle</param>
    	/// <param name="parameter">Caller-defined variable; we use it for a pointer to our list</param>
    	/// <returns>True to continue enumerating, false to bail.</returns>
    	public delegate bool EnumWindowProc(IntPtr hWnd, IntPtr parameter);
		
		
		
		void BtnHelloClick(object sender, EventArgs e)
		{
			uint wparam = 0 << 29 | 0;
          			string msg = "Hello";
          			int i = 0;
          			for (i = 0 ; i < msg.Length ; i++)
          			{
          				//PostMessage(child, WM_KEYDOWN, (IntPtr)Keys.Enter, (IntPtr)wparam);
          				PostMessage(cmdHwnd, WM_CHAR, (int)msg[i], 0);
          			}
          			PostMessage(cmdHwnd, WM_KEYDOWN, (IntPtr)Keys.Enter, (IntPtr)wparam);
		}
		
		void BtnCommandClick(object sender, EventArgs e)
		{
			uint wparam = 0 << 29 | 0;
          			string msg = textBox1.Text;
          			int i = 0;
          			for (i = 0 ; i < msg.Length ; i++)
          			{
          				//PostMessage(child, WM_KEYDOWN, (IntPtr)Keys.Enter, (IntPtr)wparam);
          				PostMessage(cmdHwnd, WM_CHAR, (int)msg[i], 0);
          			}
          			PostMessage(cmdHwnd, WM_KEYDOWN, (IntPtr)Keys.Enter, (IntPtr)wparam);
		}
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
			
		}
	}
