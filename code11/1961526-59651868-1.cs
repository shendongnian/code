cs
namespace App2
{
    public interface Interface1
    {
        void LaunchAppOnPlayStore();
    }
}
Lets go on and implement this in the **Android** project: for this purpose i add a class called `MyInterfaceImplementationAndroid ` in it and make inherit from `Interface1`. Then i implement the method from the **Interface** as follows:
using Xamarin.Forms;
using Android.Content;
using Plugin.CurrentActivity;
[assembly: Dependency(typeof(App2.Droid.MyInterfaceImplementationAndroid))]
namespace App2.Droid
{
    class MyInterfaceImplementationAndroid : Interface1
    {
        public void LaunchAppOnPlayStore()
        {
            CrossCurrentActivity.Current.AppContext.StartActivity(new Intent(Intent.ActionView, Android.Net.Uri.Parse("market://details?id=com.mycompany.myapp")));
        }
    }
}
You should note that in my example i use the `Context` provided by *CurrentActivity* plugin by @JamesMontemagno (this is just circumstantial, and in my own apps i myself use a different approach as i described in [another SO Post][2] (See the part where i add the `MainApplication` class to get the Current `Context`, or see the [blog post][3] by @DavidBritch (worth to read!)))
We are almost done! Now you just have to call the method in your shared code as follows:
For the sake of this example i created a simple page with a button:
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="App2.TestInyection">
    <ContentPage.Content>
        <StackLayout>
            <Button Text="Go to shop!"
                    Clicked="Button_Clicked"
                VerticalOptions="CenterAndExpand" 
                HorizontalOptions="CenterAndExpand" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
and in the code behind i just call the `LaunchAppOnPlayStore` method as follows:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TestInyection : ContentPage
    {
        public TestInyection()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<Interface1>().LaunchAppOnPlayStore();
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/dependency-service/introduction
  [2]: https://stackoverflow.com/questions/58801549/where-to-put-and-how-to-read-from-manually-created-db-file-using-xamarin-forms/58810278#58810278
  [3]: https://www.davidbritch.com/2017/11/xamarinforms-25-and-local-context-on.html
