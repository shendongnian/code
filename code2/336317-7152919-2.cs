    MyViewModel vm = new MyViewModel()
    ConfirmationDialogService = new MockConfirmationDialogService(false);
    vm.ExecuteCommand();
    Assert.IsFalse(vm.CommandChangedSomething);
    vm.ConfirmationDialogService = new MockConfirmationDialogService(true);
    vm.ExecuteCommand();
    Assert.IsTrue(vm.CommandChangedSomething);
