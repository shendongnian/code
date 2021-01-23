      private List<string> _processorMfgs;
            public List<string> ProcessorMfgs
            {
                get { return _processorMfgs; }
                set
                {
                    _processorMfgs = value;
                    NotifyOfPropertyChange(() => ProcessorMfgs);
                }
            }
    
        ProcessorMfgs = new List<string>
                                    {
                                        "Intel", "AMD"
                                    };
