    using System.Runtime.InteropServices;
    
    .
    .
    .
    
    [DllImport("user32.dll")]
    static extern uint MapVirtualKey(uint uCode, uint uMapType);
    
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
    									Scan = (UInt16)MapVirtualKey((UInt16)keyCode, 0),
    									Flags = IsExtendedKey(keyCode) ? (UInt32) KeyboardFlag.ExtendedKey : 0,
    									Time = 0,
    									ExtraInfo = IntPtr.Zero
    								}
    					}
    			};
    
    	_inputList.Add(down);
    	return this;
    }
    
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
    									Scan = (UInt16)MapVirtualKey((UInt16)keyCode, 0),
    									Flags = (UInt32) (IsExtendedKey(keyCode)
    														  ? KeyboardFlag.KeyUp | KeyboardFlag.ExtendedKey
    														  : KeyboardFlag.KeyUp),
    									Time = 0,
    									ExtraInfo = IntPtr.Zero
    								}
    					}
    			};
    
    	_inputList.Add(up);
    	return this;
    }
