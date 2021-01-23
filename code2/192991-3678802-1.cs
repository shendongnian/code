        private otherClass
        public AnswerViewModel()
        {
            PropertyChanged += (sender, args) => 
            {
                if(args.PropertyName == "Property1" || args.PropertyName == "Property2")
                    otherClass.DoStuff();
            }
        }
