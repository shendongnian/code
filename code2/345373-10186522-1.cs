    const int WM_KEYDOWN = 0x100;
    const int WM_SYSKEYDOWN = 0x104;
    if  ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))) // Only act on on keydown
    {
      // allkeys will contian something like "LEFT,SHIFT". Carefull in debugger:
      // Tooltip and Watch value still assumes powers of 2 and will show wrong values
      string allkeys = keys.ToString().ToUpper();
      bool shift = allkeys.contains("SHIFT");
      bool alt = allkeys.contains("ALT");
      bool control = allkeys.contains("CONTROL");
      if(allkeys.Contains("UP"))
      {}
      else if(allkeys.Contains("DOWN"))
      {}
      else if(allkeys.Contains("LEFT"))
      {}
      else (allkeys.Contains("RIGHT"))
      {}
    }
