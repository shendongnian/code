    using System.Runtime.InteropServices;
    .
    .
    .
    [DllImport("user32.dll")]
    static extern uint MapVirtualKeyEx(uint uCode, uint uMapType, IntPtr dwhkl);
    
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    static extern short VkKeyScanEx(char ch, IntPtr dwhkl);
    .
    .
    .
    public InputBuilder AddKeyDown(VirtualKeyCode keyCode)
    {
    	var down =
    		new INPUT
    		{
    			Type = (UInt32)InputType.Keyboard,
    			Data =
    					{
    						Keyboard =
    							new KEYBDINPUT
    								{
    									KeyCode = (UInt16) keyCode,
    									Scan = (UInt16)MapVirtualKeyEx((UInt16)keyCode, 0, IntPtr.Zero),
    									Flags = IsExtendedKey(keyCode) ? (UInt32) KeyboardFlag.ExtendedKey : (UInt32) KeyboardFlag.ScanCode,
    									Time = 0,
    									ExtraInfo = IntPtr.Zero
    								}
    					}
    			};
    
    	_inputList.Add(down);
    	return this;
    }
    .
    .
    .
    public InputBuilder AddKeyUp(VirtualKeyCode keyCode)
    {
    	var up =
    		new INPUT
    			{
    				Type = (UInt32) InputType.Keyboard,
    				Data =
    					{
    						Keyboard =
    							new KEYBDINPUT
    								{
    									KeyCode = (UInt16) keyCode,
    									Scan = (UInt16)MapVirtualKeyEx((UInt16)keyCode, 0,IntPtr.Zero),
    									Flags = (UInt32) (IsExtendedKey(keyCode)
    														  ? KeyboardFlag.KeyUp | KeyboardFlag.ExtendedKey
    														  : KeyboardFlag.KeyUp | KeyboardFlag.ScanCode),
    									Time = 0,
    									ExtraInfo = IntPtr.Zero
    								}
    					}
    			};
    
    	_inputList.Add(up);
    	return this;
    }
    .
    .
    .
    public InputBuilder AddCharacter(char character)
    {
    	bool shiftChr = ((UInt16)VkKeyScanEx(character, IntPtr.Zero) >> 8).Equals(1);
    	if (shiftChr)
    	{
    		AddKeyDown(VirtualKeyCode.VK_SHIFT);
    	}
    
    	UInt16 scanCode = shiftChr ? (UInt16)MapVirtualKeyEx((UInt16)(VkKeyScanEx(character, IntPtr.Zero) & 0xff),0,IntPtr.Zero) : (UInt16)MapVirtualKeyEx((UInt16)VkKeyScanEx(character, IntPtr.Zero), 0, IntPtr.Zero);
    
    	var down = new INPUT
    				   {
    					   Type = (UInt32)InputType.Keyboard,
    					   Data =
    						   {
    							   Keyboard =
    								   new KEYBDINPUT
    									   {
    										   KeyCode = 0,
    										   Scan = scanCode,
    										   Flags = (UInt32)KeyboardFlag.ScanCode,
    										   Time = 0,
    										   ExtraInfo = IntPtr.Zero
    									   }
    						   }
    				   };
    
    	var up = new INPUT
    				 {
    					 Type = (UInt32)InputType.Keyboard,
    					 Data =
    						 {
    							 Keyboard =
    								 new KEYBDINPUT
    									 {
    										 KeyCode = 0,
    										 Scan = scanCode,
    										 Flags =
    											 (UInt32)(KeyboardFlag.KeyUp | KeyboardFlag.ScanCode),
    										 Time = 0,
    										 ExtraInfo = IntPtr.Zero
    									 }
    						 }
    				 };
    
    	_inputList.Add(down);
    	_inputList.Add(up);
    	
    	if (shiftChr)
    	{
    		AddKeyUp(VirtualKeyCode.VK_SHIFT);
    	}
    
    	return this;
    }
