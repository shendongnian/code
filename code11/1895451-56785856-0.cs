    public class ClassA
    {
        MyDialogViewModel vm = new MyDialogViewModel { Name = "X", Roll = "Y" };
        MyDialog dlg = new MyDialog();
        dlg.ShowDialog();
        var name = vm.Name;
        var roll = vm.roll;
        // Do something to persist your data as necessary. Either here or in a model within the viewmodel
    }
