    public static class GunEvents {
       
       delegate void ClipIsLowEvent();
       public static event ClipIsLowEvent OnClipIsLow;
    
       //this is how we fire the event
       public static void ClipIsLow(){
           OnClipIsLow?.Invoke();
       }
    }
