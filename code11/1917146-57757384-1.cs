    public partial class App : Application
    {
        public void OnProtocolActivated(IActivatedEventArgs args)
        {
            switch (args.Kind)
            {
                case ActivationKind.File:
                    //handle file activation
                    break;
            }
        }
    }
