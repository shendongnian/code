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
**UPDATED**
5. Change `ItemsSource` binding statement like this (I changed (s)tudents to (S)tudents):
xaml
ItemsSource="{Binding Students, NotifyOnTargetUpdated=True,UpdateSourceTrigger=PropertyChanged}"
Output:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/yxeRl.gif
