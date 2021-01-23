    ObservableCollection<AppVariable<G>> _appVariables = new new ObservableCollection<AppVariable<G>>();
    var temp = AppRepository.AppVariables.Where(i => i.IsChecked == true).OrderByDescending(k=>k.Index);
    foreach (var i in temp)
    {
         AppRepository.AppVariables.RemoveAt(i.Index);
    }
                
