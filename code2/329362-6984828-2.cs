    interface Command {
        void Execute(object parameters);    
        bool CanExecute(object parameters);
    }
    class CommandImpl: ICommand {
        private IDictionary<object, bool> ParametersChecked {get; set;}
        public void Execute(object parameters){
            if(!CanExecute(parameters)) throw new ApplicationException("...");
            /** Execute implementation **/
        }
        public bool CanExecute(object parameters){
            if (ParametersChecked.ContainsKey(parameters))
                return ParametersChecked[parameters];
            var result = ... // your check here
            ParametersChecked.Add(parameters, result);
        }
    }
