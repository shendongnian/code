    namespace WpfApplication1
    {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new EditorView();
        }
    }
    public class Image 
    
    { 
        public string Name { get; set;} 
        public IEnumerable<Effect> Effects { get; set; } 
        public IEnumerable<Layer> Layers { get; set; }
        public IEnumerable<Node> Nodes { get { return ((IEnumerable<Node>)Layers).Union((IEnumerable<Node>)Effects); } }
    }
    public class Effect : Node
    {
        public Effect(string name) 
        { 
            this.Name = name; 
        } 
    }
    public class Layer : Node
    { 
          public Layer(string name) { this.Name = name; } 
    }
    public class Node
    {
        public string Name { get; set; }
        public string Icon { get; set; }
    }
    public class EditorView : INotifyPropertyChanged 
    {
        public EditorView()
        {
            Image img = new Image();
            WpfApplication1.Effect effect = new WpfApplication1.Effect("Effect1");
            WpfApplication1.Layer layer = new Layer("Layer1");
            img.Name = "Image1";
            List<Effect> effects = new List<WpfApplication1.Effect>();
            effects.Add(effect);
            img.Effects = effects;
            List<Layer> layers = new List<Layer>();
            layers.Add(layer);
            img.Layers = layers;
            List<WpfApplication1.Image> Images = new List<Image>();
            Images.Add(img);
            this.Images = Images;
        }
        
        IEnumerable<Image> images;
        public IEnumerable<Image> Images 
        { 
            get 
        { 
                return images; 
        } 
            set { this.images = value; this.RaisePropertyChanged("Images"); 
            } 
        } public event 
            PropertyChangedEventHandler 
            PropertyChanged; 
        void RaisePropertyChanged(string propertyName) 
        { var handler = this.PropertyChanged; 
            if (handler != null)            
                
                handler(this, new PropertyChangedEventArgs(propertyName)); 
        } 
    }
    }
