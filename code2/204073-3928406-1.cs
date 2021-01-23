    public class SomeView: UIView { 
    
        MyPickerViewModel _model;
    
        SomeView(MyPickerViewModel model) {  
            _model = model;
    
            _model.SelectionChanged += delegate(object s, EventArgs e) {   
                DoSomething();  
            }  
    
            _model.PrintWhetherSelectionChangedIsNull(); // prints "no"  
        }  
    
        private void DoSomething() { /* should be called now */ }  
    }
