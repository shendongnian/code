     public void Log_A(string input)
     {
         if (Log.IsDebugEnabled)
             Log.Debug(input);
     }
     public void Log_B(FormattableString input)
     {
         if (Log.IsDebugEnabled)
             Log.Debug(input.ToString());
     }
     
     // string.Format is called before entering Log_A
     Log_A($"Something happened with {x} and {y}");
     
     // if Log.IsDebugEnabled is false, string.Format will not be called
     Log_B($"Something happened with {x} and {y}");
