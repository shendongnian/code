    using System;
    using System.Windows;
    using System.Windows.Data;
    using System.Collections.ObjectModel;
    using System.Windows.Threading;
    
    namespace ContextTest
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = new ViewModel();
            }
        }
    
        public class ViewModel
        {
            private DataGenerator dataGenerator;
            private ObservableCollection<Model> modelCollection;
            public ListCollectionView ModelCollectionView { get; private set; }
    
            public ViewModel()
            {
                modelCollection = new ObservableCollection<Model>();
                ModelCollectionView = new ListCollectionView(modelCollection);
    
                //Create models
                for (int i = 0; i < 20; i++)
                    modelCollection.Add(new Model() { Name = "Model" + i.ToString(), 
                        Description = "Description for Model" + i.ToString() });
    
                this.dataGenerator = new DataGenerator(this);
            }
    
            public void Replace(Model oldModel, Model newModel)
            {
                int curIndex = ModelCollectionView.CurrentPosition;
                int n = modelCollection.IndexOf(oldModel);
                this.modelCollection[n] = newModel;
                ModelCollectionView.MoveCurrentToPosition(curIndex);
            }
        }
    
        public class Model
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    
        public class DataGenerator
        {
            private ViewModel vm;
            private DispatcherTimer timer;
            int ctr = 0;
    
            public DataGenerator(ViewModel vm)
            {
                this.vm = vm;
                timer = new DispatcherTimer(TimeSpan.FromSeconds(5), 
                    DispatcherPriority.Normal, OnTimerTick, Dispatcher.CurrentDispatcher);
            }
    
            public void OnTimerTick(object sender, EventArgs e)
            {
                Random r = new Random();
    
                //Update several Model items in the ViewModel
                int times = r.Next(vm.ModelCollectionView.Count - 1);
                for (int i = 0; i < times; i++)
                {   
                    Model newModel = new Model() 
                        { 
                            Name = "NewModel" + ctr.ToString(),
                            Description = "Description for NewModel" + ctr.ToString()
                        };
                    ctr++;
    
                    //Replace a random item in VM with a new one.
                    int n = r.Next(times);
                    vm.Replace(vm.ModelCollectionView.GetItemAt(n) as Model, newModel);
                }
            }
        }
    }
