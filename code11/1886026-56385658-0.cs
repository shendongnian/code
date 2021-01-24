lang-xml
<Window x:Class="ExampleProject.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:ExampleProject"
        xmlns:viewmodel="clr-namespace:ExampleProject.ViewModel"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <!-- we reference our CounterViewModel class via XAML here. note that to access it, 
    we need to specify the namespace it's in by adding 
    xmlns:viewmodel="clr-namespace:ExampleProject.ViewModel"-->
    <Window.Resources>
        <viewmodel:CounterViewModel x:Key="Counter"></viewmodel:CounterViewModel>
    </Window.Resources>
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
        </Grid.RowDefinitions>
        <!-- here we bind to the Counter property in the viewmodel. we reference it in 
        XAML via the value assigned to x:Key (in this case, Counter). the value assigned
        to the "Source" parameter tells WPF where to look for properties. the value
        assigned to Path tells it which property to bind to.-->
        <TextBlock Grid.Row="0" 
                   Text="{Binding Source={StaticResource Counter}, Path=Counter}" 
                   FontSize="50" 
                   HorizontalAlignment="Center" 
                   VerticalAlignment="Center"/>
        <Button Grid.Row="1" 
                Content="Press Me" 
                Command="{Binding Source={StaticResource Counter}, Path=Increment}"
                CommandParameter="{StaticResource Counter}"
                FontSize="60"></Button>
    </Grid>
</Window>
ViewModel:
lang-cs
using System.ComponentModel;
using System.Windows.Input;
using ExampleProject.Commands;
using ExampleProject.Model;
namespace ExampleProject.ViewModel
{
    //this is the viewmodel. note that it implements INotifyPropertyChanged.
    //you almost always want your viewmodel to do so.
    public class CounterViewModel : INotifyPropertyChanged
    {
        //invoke this whenever you change a property that your controls 
        //might be binding to
        public event PropertyChangedEventHandler PropertyChanged;
        //this is the underlying data. including a reference to the model in
        //your viewmodel is one way to facilitate communication between the 
        //two, although there are other ways.
        private CounterModel model;
        //this is the most important part; your view will bind to this.
        public int Counter
        {
            get { return model.Counter; }
            set
            {
                model.Counter = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Counter"));
            }
        }
        //this is a function that will increment the counter and can be called
        //directly from XAML.
        public ICommand Increment { get; }
        //this constructor needs to be parameterless in our case, because
        //we will be creating an instance of this class from XAML.
        public CounterViewModel()
        {
            model = new CounterModel(0);
            Increment = new IncrementCommand();
        }
    }
}
Model:
lang-cs
namespace ExampleProject.Model
{
    //this is a simple model class. generally, you don't want to
    //implement any logic here; in pure MVVM the model just 
    //encapsulates raw data. 
    public class CounterModel
    {
        public int Counter;
        public CounterModel(int counterValue)
        {
            Counter = counterValue;
        }
    }
}
Increment command:
lang-cs
using System;
using System.Windows.Input;
using ExampleProject.ViewModel;
namespace ExampleProject.Commands
{
    public class IncrementCommand : ICommand
    {
        //necessary to implement because of ICommand but we're not currently using this
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            //if this method returns false, the command won't be executed.
            return true;
        }
        public void Execute(object parameter)
        {
            //parameter is passed in via XAML; it's always an instance of CounterViewModel
            //but i double-check what kind of object it is anyway.
            if (parameter is CounterViewModel viewModel)
            {
                viewModel.Counter++;
            }
        }
    }
}
Note that I didn't need to add anything to the code-behind. This isn't always possible, but it's often a good thing when you can manage it.
