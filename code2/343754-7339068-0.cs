    public class YourViewModel : DependencyObject {
    	public string[] FictionArray {get; private set;}
	
	    public IObservable<string> AvailableIndices;
	    public static readonly DependencyProperty SelectedIndexProperty=
          DependencyProperty.Register("SelectedIndex", typeof(string), typeof(YourViewModel), new PropertyMetadata((s,e) => {
		    var viewModel = (YourViewModel) s;
		    var index = Convert.ToInt32(e.NewValue);
		    if (index >= 0 && index < viewModel.FictionArray.Length)
			    viewModel.TextBoxText=FictionArray[index];
	      }));
        public bool SelectedIndex {
          get { return (bool)GetValue(SelectedIndexProperty); }
          set { SetValue(SelectedIndexProperty, value); }
        }
	
	    public static readonly DependencyProperty TextBoxTextProperty=
          DependencyProperty.Register("TextBoxText", typeof(string), typeof(YourViewModel));
        public bool TextBoxText {
          get { return (bool)GetValue(TextBoxTextProperty); }
          set { SetValue(TextBoxTextProperty, value); }
        }
	
	    public YourViewModel(string[] fictionArray) {
	     	FictionArray = fictionArray;
		    for (int i = 0; i < FictionArray.Length; i++){
			    AvailableIndices.Add(i.ToString()));
		    }
	    }
    }
