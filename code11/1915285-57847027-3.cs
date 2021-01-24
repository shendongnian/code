csharp
using System;
using System.Threading;
using Xamarin.Forms;
namespace CancelTextToSpeechSample
{
    public class App : Application
    {
        public App()
        {
            MainPage = new CancelSpeakPage();
        }
        class CancelSpeakPage : ContentPage
        {
            const string _spokenText = "Oh, supercalifragilisticexpialidocious! Even though the sound of it, Is something quite atrocious, If you say it loud enough, You'll always sound precocious, Supercalifragilisticexpialidocious!";
            CancellationTokenSource _speakButtonCancellationTokenSource;
            public CancelSpeakPage()
            {
                var speakButton = new Button { Text = "Sing" };
                speakButton.Clicked += HandleSpeakButtonClicked;
                var cancelButton = new Button { Text = "Cancel Song" };
                cancelButton.Clicked += HandleCancelButtonClicked;
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Children =
                    {
                        speakButton,
                        cancelButton
                    }
                };
            }
            void HandleCancelButtonClicked(object sender, EventArgs e)
            {
                _speakButtonCancellationTokenSource?.Cancel();
            }
            async void HandleSpeakButtonClicked(object sender, EventArgs e)
            {
                if (_speakButtonCancellationTokenSource?.IsCancellationRequested is false)
                    _speakButtonCancellationTokenSource.Cancel();
                _speakButtonCancellationTokenSource = new CancellationTokenSource();
                await Xamarin.Essentials.TextToSpeech.SpeakAsync(_spokenText, _speakButtonCancellationTokenSource.Token);
            }
        }
    }
}
