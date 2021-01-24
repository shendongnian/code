C#
public ObservableCollection<Students> Students
{
    get { return _students; }
    set
    {
        if (_students == value) return;
        _students = value;
        OnPropertyChanged(nameof(Students));
    }
}
2. Set `dataOnOff` variable to `true` in ViewModel constructor:
c#
public MyViewModel()
{
    dataOnOff = true;
    ReadCommand = new RelayCommand(DoRead);
}
3. Call `FillList` method in `DoRead`, as mentioned in comments:
C#
public void DoRead(object param)
{
    FillList(param);
    dataOnOff = true;
    MessageBox.Show("s");
}
4. Specify a ViewModel for your window:
xaml
<Window.DataContext>
    <nameSpace:MyViewModel/>
</Window.DataContext>
