    //MobileFunnelPage.cs  
    public abstract class MobileFunnelPage : Page  
    {  
        public abstract Repeater MyRepeater { get; set; }  
    }
    //ConcreteMobileFunnelPage.aspx.cs  
    public class ConcreteMobileFunnelPage : MobileFunnelPage  
    {  
        public override Repeater MyRepeater {
            get {
               return myRepeater;
            }
            set {
               myRepeater = value;
            }
        }
    }
