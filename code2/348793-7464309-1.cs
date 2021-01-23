    using System;
    using Windows.Data.Xml.Dom;
    using Windows.UI.Notifications;
    using Windows.UI.Xaml;
    
    namespace TileNotificationCS
    {
        partial class MainPage
        {
            TileUpdater tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
    
            public MainPage()
            {
                InitializeComponent();
            }
    
            private void changeTile_Click(object sender, RoutedEventArgs e)
            {
                XmlDocument tileXml = TileUpdateManager.GetTemplateContent(TileTemplateType.TileWideText01);
                XmlElement textElement = (XmlElement)tileXml.GetElementsByTagName("text")[0];
                textElement.AppendChild(tileXml.CreateTextNode(message.Text));
                tileUpdater.Update(new TileNotification(tileXml));
            }
        }
    }
