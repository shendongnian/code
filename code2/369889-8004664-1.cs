    using System;
    using System.Net;
    using System.Runtime.Serialization.Json;
    using System.Windows;
    using Microsoft.Phone.Controls;
    namespace WP7JsonClient
    {
      public partial class MainPage : PhoneApplicationPage
      {
        public MainPage()
        {
          InitializeComponent();
        }
        private void button1_Click( object sender, RoutedEventArgs e )
        {
          var client = new WebClient();
          // Callback function written in-line as a lambda statement
          client.OpenReadCompleted +=
            ( s, eargs ) =>
            {
              var serializer = new DataContractJsonSerializer( typeof( ExchangeRate ) );
              var exchangeRate = (ExchangeRate)serializer.ReadObject( eargs.Result );
              
              // display exchange rate data here...
            };
          var uri = new Uri( "http://www.google.com/ig/calculator?hl=en&q=10USD=?DKK" );
          client.OpenReadAsync( uri );
        }
      }
    }
