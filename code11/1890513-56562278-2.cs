    using Prism.Commands;
    using Prism.Mvvm;
    using System.Windows;
    namespace Test.Views
    {
        public class MainWindowViewModel : BindableBase
        {        
            private string _title = "TestDrop";
            public string Title
            {
                get { return _title; }
                set { SetProperty(ref _title, value); }
            }
    
            public MainWindowViewModel()
            {            
                DropFile = new DelegateCommand<DragEventArgs>(dropFile);
            }
            
            public DelegateCommand<DragEventArgs> DropFile { get; }
    
            private void dropFile(DragEventArgs obj)
            {
                var files = obj.Data.GetData(DataFormats.FileDrop, true) as string[];
    
                //implement rest of code here
            }
        }
    }
