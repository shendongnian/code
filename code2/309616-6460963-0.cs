    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace Test
    {
        public class ContentCard : HeaderedContentControl
        {
            static ContentCard()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(ContentCard), new FrameworkPropertyMetadata(typeof(ContentCard)));
            }
        }
    }
