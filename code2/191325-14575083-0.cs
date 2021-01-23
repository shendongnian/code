            INPUT[] inputs = new INPUT[1];
            inputs[0].type = INPUT_KEYBOARD;
            KEYBDINPUT  kb = new KEYBDINPUT(); //{0};
            // generate down 
            if ( bExtended )
                kb.dwFlags  = KEYEVENTF_EXTENDEDKEY;
            
            kb.wVk  = (ushort)vk;  
            inputs[0].ki = kb;
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
            
            // generate up 
            //ZeroMemory(&kb, sizeof(KEYBDINPUT));
            //ZeroMemory(&inputs,sizeof(inputs));
            kb.dwFlags  =  KEYEVENTF_KEYUP;
            if ( bExtended )
                kb.dwFlags  |= KEYEVENTF_EXTENDEDKEY;
            kb.wVk    =  (ushort)vk;
            inputs[0].type =  INPUT_KEYBOARD;
            inputs[0].ki  =  kb;
            SendInput(1, inputs, System.Runtime.InteropServices.Marshal.SizeOf(inputs[0]));
        }
