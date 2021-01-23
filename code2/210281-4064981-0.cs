    ParentViewModel vm = (ParentViewModel)DataContext;
    vm.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "ChildViewModel")
        {
            MyChildWindow w = new MyChildWindow();
            w.Show(vm.ChildViewModel);
        }
    };
