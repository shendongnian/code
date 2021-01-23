    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Create a collection of IDisposable
            // to allow clean-up of subscriptions
            var subscriptions =
                new System.Reactive.Disposables.CompositeDisposable();
            var formClosings = Observable
                .FromEventPattern<FormClosingEventHandler, FormClosingEventArgs>(
                    h => this.FormClosing += h,
                    h => this.FormClosing -= h);
            // Add a subscription that cleans up subscriptions
            // when the form closes
            subscriptions.Add(
                formClosings
                    .Subscribe(ea => subscriptions.Dispose()));
