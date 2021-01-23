    public interfacte ITreeViewModel
    {
        public TstTreeNode TestNode {get;}
        ........
        // Other members
    }
    // Sample Class
    public class TreeViewModel : ITreeViewModel
    {
        public TreeViewModel(TstTreeNode node) {
           TestNode = node;
        }
        // Implemented from interface
        public TstTreeNode TestNode {get; private set;}
    }
    // Your code
    IKernel kernel = new StandardKernel();
    kernel.Bind<ITeleStore>().To<TeleStore>();
    kernel.Bind<ITreeViewModel>().To<TreeViewModel>();
    var tst = kernel.Get<TeleStore>();
    // rootnode already exists and is obtained from the telestore component
    TstTreeNode rootNode = tst.GetRootNode();
    // how do I use ninject to inject rootnode?
    ITreeViewModel treeViewModel = kernel.Get<TreeViewModel>(new ConstructorArgument("node", rootNode));
