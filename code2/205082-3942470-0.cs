        private IEnumerable<ViewModel> GetInvalidModels(ViewModel[] viewModels)
        {
            return 
                from viewModel in viewModels 
                from prop in typeof(ViewModel).GetProperties() 
                let ruleType = ((KeyValuePair<object, ViewModel>)prop.GetValue(viewModel, null)).Value 
                where ruleType != RuleType.Success 
                select viewModel;
        }
