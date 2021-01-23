    public class TransparencyRulesDemo
    {
        [SecuritySafeCritical]
        public void SafeGetCritical()
        {
            GetCritical();
        }
        public void TransparentGetCritical()
        {
            // Below line will trigger a CA2140 warning if uncommented...
            // var critical = GetCritical();
            // ...the following line on the other hand will not produce any warning
            // but will lead to IL verification errors and MethodAccessExceptions if
            // called from transparent code.
            GetCritical();
        }
        [SecuritySafeCritical]
        public Critical GetCritical()
        {
            return new Critical();
        }
    }
    [SecurityCritical]
    public class Critical
    {
        
    } 
