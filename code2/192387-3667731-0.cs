    namespace Kinetics {
    
    public class KineticsCommand : RMA.Rhino.MRhinoCommand 
    { 
       Splash splashVariable= new Splash(); 
       splashVariable.Show(); 
    } 
     
    public partial class Splash : Form 
    { 
        public Splash() 
        { 
            InitializeComponent(); 
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
                     ref MRhinoObject old, ref MRhinoObject obj, 
                     Splash splashScreen) 
        { 
           // to access the instance of the class from here, 
           // pass in the variable that holds a reference to the instance
           splashScreen.[Whatever];
        } 
    } 
