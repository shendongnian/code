    namespace Kinetics {
    
    public class KineticsCommand : RMA.Rhino.MRhinoCommand 
    { 
       Splash splashVariable= Splash.SingletonInstance; 
       splashVariable.Show(); 
       // or, combine and just write...
       Splash.SingletonInstance.Show();
    } 
     
    public partial class Splash : Form 
    { 
        private Splash splsh;
        private Splash() 
        { 
            InitializeComponent(); 
        } 
        public static Splash SingletonInstance  // Factory property
        {
            get { return splsh?? (splsh = new Splash()); }
        }
        //  Factory Method would be like this:
        public static Splash GetSingletonInstance()  // Factory method
        {
            return splsh?? (splsh = new Splash()); 
        }
        private void timer1_Tick(object sender, EventArgs e) 
        { 
            this.Close(); 
     
            MainUI MainWindow = new MainUI(); 
            MainWindow.Show(); 
        } 
    } 
     
    public class CustomEventWatcher : MRhinoEventWatcher 
    { 
     
     
        public override void OnReplaceObject(ref MRhinoDoc doc, 
                     ref MRhinoObject old, ref MRhinoObject obj) 
        { 
           // to access the instance of the class from here,  now 
           // all you need to do is call the static factory property
           // defined on the class itself.
           Splash.SingletonInstance.[Whatever];
        } 
    } 
 
