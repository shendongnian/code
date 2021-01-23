        protected PremiseProperty<bool> _Trigger = new PremiseProperty<bool>("Trigger");
        public bool Trigger
        {
            set
            {
                if (value == true)
                    RaisePropertyChanged(_Trigger.PropertyName, false, value, true);
            }
        }
