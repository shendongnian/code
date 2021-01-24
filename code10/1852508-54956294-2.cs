    public class ButtonViewModel : ReactiveObject
    {
        [Reactive]
        public ICommand Command { get; set; }
	}
