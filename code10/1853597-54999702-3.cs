    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reactive;
    using System.Reactive.Linq;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Windows.Foundation.Collections;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Controls.Primitives;
    using Windows.UI.Xaml.Data;
    using Windows.UI.Xaml.Input;
    using Windows.UI.Xaml.Media;
    using Windows.UI.Xaml.Navigation;
    namespace App5
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page
        {
            private IDisposable _subscription = null;
            public MainPage()
            {
                this.InitializeComponent();
                IObservable<EventPattern<TextChangedEventArgs>> textChanges =
                    Observable
                        .FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
                            h => textBox1.TextChanged += h,
                            h => textBox1.TextChanged -= h);
                IObservable<string> query =
                    textChanges
                        .Select(x =>
                            Observable
                                .FromAsync(() => PerformSearchAsync(textBox1.Text))
                                .StartWith("Searching..."))
                        .Switch();
                _subscription =
                    query
                        .ObserveOnDispatcher()
                        .Subscribe(x => textBlock1.Text = x);
            }
            private async Task<string> PerformSearchAsync(string text)
            {
                await Task.Delay(TimeSpan.FromSeconds(2.0));
                return "Hello " + text;
            }
        }
    }
