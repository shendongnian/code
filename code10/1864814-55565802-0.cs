    using Ninject;
    using Ninject.Modules;
    using Ninject.Parameters;  
    //Add new class  
    public class CompositionRoot
    {
        public static IKernel _ninjectKernel;
        public static void Wire(INinjectModule module)
        {
            _ninjectKernel = new StandardKernel(module);
        }
        public static T Resolve<T>()
        {
            return _ninjectKernel.Get<T>();
        }
        public static T ResolveWithArgument<T>(ConstructorArgument argument)
        {
            return _ninjectKernel.Get<T>(argument);
        }
    }
   
    //Ninject bindings
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<LogToDB>();
            Bind<ICopy>().To<CopyToFolder>();            
        }
    }
    //WinForm - Form1
    public partial class Form1 : Form
    {
        public readonly ILogger _processRepository;
        public readonly Icopy _copy;
        public readonly int ValueToEdit;
        public Form1(ILogger logger, ICopy copy, int valueToEdit)
        {
            this._processRepository = logger;
            this._copy = copy;
            this.ValueToEdit = valueToEdit;
            InitializeComponent();
        }
    }
    //main
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
       //Apply the binding rule first
       CompositionRoot.Wire(new Bindings());   
       //Then resolve your form dependencies this way using Ninject passing along the 
       constructor arguments. 
       CompositionRoot.ResolveWithArgument<Form1>(new ConstructorArgument("valueToEdit", 
       1)).ShowDialog();      
    }
   
