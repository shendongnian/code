csharp
using System.Windows;
using System.Windows.Controls;
namespace WpfControlLibrary1
{
    public class MyTextBox : TextBox
    {
        static MyTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyTextBox), new FrameworkPropertyMetadata(typeof(MyTextBox)));
        }
        //public MyTextBox()
        //{
        //    DefaultStyleKey = typeof(MyTextBox);
        //}
    }
}
## Testapplication (Testbase)
**App.xaml**
xaml
<Application x:Class="Testbase.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:local="clr-namespace:Testbase"
             StartupUri="MainWindow.xaml">
    <Application.Resources>
         <ResourceDictionary>
             <ResourceDictionary.MergedDictionaries>
                 <ResourceDictionary Source="pack://application:,,,/WpfControlLibrary1;component/generic/Themes.xaml" />
             </ResourceDictionary.MergedDictionaries>
         </ResourceDictionary>
    </Application.Resources>
</Application>
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/TupMZ.png
