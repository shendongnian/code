            private INumbersModel _model;
            private INumbersBusinessLayer _numbersBusinessLayer;
    
            public NumbersController(INumbersModel model,INumbersBusinessLayer numbersBusinessLayer)
            {
                _model = model;
                _numbersBusinessLayer = numbersBusinessLayer
            }
