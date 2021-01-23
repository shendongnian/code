    private int getDebugLog(String name)
    {
      int rValue;
      myKey = Registry.LocalMachine.OpenSubKey(regKey + name, false);
      object o = myKey.GetValue("DebugLog");
      if (o != null) {
        rValue = o.ToString();
        if (!String.IsNullOrEmpty(rValue)) {
          return Convert.ToInt32(Convert.ToDecimal(rValue));
        }
      }
      return null;
    }
