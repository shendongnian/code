<Window x:Class="GridColumnVisibilityToggle.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:s="clr-namespace:System;assembly=System.Runtime"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <DataGrid x:Name="TheDataGrid"
                  AutoGenerateColumns="False" 
                  HorizontalScrollBarVisibility="Auto" 
                  IsReadOnly="True" 
                  AreRowDetailsFrozen="True" 
                  HeadersVisibility="All" >
            <DataGrid.ItemsSource>
                <x:Array Type="{x:Type s:String}">
                    <s:String>Item 1</s:String>
                    <s:String>Item 2</s:String>
                    <s:String>Item 3</s:String>
                </x:Array>
            </DataGrid.ItemsSource>
            <DataGrid.Columns>
                <DataGridTextColumn Binding="{Binding .}" Header="Header" />
            </DataGrid.Columns>
        </DataGrid >
    </Grid>
</Window>
MainWindow.xaml.cs
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
namespace GridColumnVisibilityToggle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnContentRendered(EventArgs e)
        {
            base.OnContentRendered(e);
            var cm = new ContextMenu();
            var visibilityItem = new MenuItem { Header = "Toggle Visibility" };
            var columnItems = TheDataGrid.Columns.Select(a => new MenuItem
            {
                Header = a.Header,
                Command = new RelayCommand<DataGridColumn>(column => column.Visibility = column.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible),
                CommandParameter = a
            });
            foreach (var item in columnItems)
            {
                visibilityItem.Items.Add(item);
            }
            cm.Items.Add(visibilityItem);
            TheDataGrid.ContextMenu = cm;
        }
    }
}
The ICommand implementation I've used
using System;
using System.Reflection;
using System.Windows.Input;
namespace GridColumnVisibilityToggle
{
    public class RelayCommand : ICommand
    {
        private readonly Func<object, bool> _canExecute;
        private readonly Action<object> _execute;
        public RelayCommand(Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            _execute = execute;
        }
        public RelayCommand(Action execute)
          : this((Action<object>)(o => execute()))
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
          : this(execute)
        {
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }
            _canExecute = canExecute;
        }
        public RelayCommand(Action execute, Func<bool> canExecute)
          : this((Action<object>)(o => execute()), (Func<object, bool>)(o => canExecute()))
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute(parameter);
            }
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public void ChangeCanExecute()
        {
            var canExecuteChanged = CanExecuteChanged;
            if (canExecuteChanged == null)
            {
                return;
            }
            canExecuteChanged((object)this, EventArgs.Empty);
        }
    }
    public sealed class RelayCommand<T> : RelayCommand
    {
        public RelayCommand(Action<T> execute)
            : base((Action<object>)(o =>
            {
                if (!RelayCommand<T>.IsValidParameter(o))
                {
                    return;
                }
                execute((T)o);
            }))
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
        }
        public RelayCommand(Action<T> execute, Func<T, bool> canExecute)
            : base((Action<object>)(o =>
            {
                if (!RelayCommand<T>.IsValidParameter(o))
                {
                    return;
                }
                execute((T)o);
            }), (Func<object, bool>)(o =>
            {
                if (RelayCommand<T>.IsValidParameter(o))
                {
                    return canExecute((T)o);
                }
                return false;
            }))
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }
            if (canExecute == null)
            {
                throw new ArgumentNullException(nameof(canExecute));
            }
        }
        private static bool IsValidParameter(object o)
        {
            if (o != null)
            {
                return o is T;
            }
            var type = typeof(T);
            if (Nullable.GetUnderlyingType(type) != (Type)null)
            {
                return true;
            }
            return !type.GetTypeInfo().IsValueType;
        }
    }
}
It generates the `DataGrid`'s `ContextMenu` in the `OnContentRendered` method. For each `DataGridColumn` a `MenuItem` get's generated with a command that either shows or hides it.
