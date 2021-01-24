    public partial class View : Form
    {    
        private ViewModel _viewmodel;
    
        public View()
        {
            InitializeComponent();   
            var model = new Model { X = 10, Y = 20 }  
            _viewmodel = new ViewModel(model);
            // Bind controls to the viewmodel
            textboxForX.DataBindings.Add("Text", _viewmodel, "X", true);
            textboxForY.DataBindings.Add("Text", _viewmodel, "Y", true);
            labelForResult.DataBindings.Add("Text", _viewmodel, "Result", true);            
        } 
        private void CalculateButton_Click(object sender, EvetnArgs e)
        {
            _viewmodel.Calculate();
        }
    }    
