    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace TagCloudDemo
    {
        public partial class TagCloudControl : UserControl
        {
            public TagCloudControl()
            {
                InitializeComponent();
            }
    
            public IEnumerable<string> Words
            {
                get { return (IEnumerable<string>)GetValue(WordsProperty); }
                set { SetValue(WordsProperty, value); }
            }
    
            public static readonly DependencyProperty WordsProperty =
                DependencyProperty.Register("Words", 
                                            typeof(IEnumerable<string>), 
                                            typeof(TagCloudControl), 
                                            new UIPropertyMetadata(new List<string>(), WordsChanged));
    
            public IEnumerable<Tag> Tags
            {
                get { return (IEnumerable<Tag>)GetValue(TagsProperty); }
                set { SetValue(TagsProperty, value); }
            }
    
            public static readonly DependencyProperty TagsProperty =
                DependencyProperty.Register("Tags", 
                                            typeof(IEnumerable<Tag>), 
                                            typeof(TagCloudControl),
                                            new UIPropertyMetadata(new List<Tag>(), TagsChanged));
    
            private static void WordsChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                TagCloudControl tagCloudControl = sender as TagCloudControl;
                tagCloudControl.Tags = TagCloudDemo.Tag.CreateTags(tagCloudControl.Words);
            }
    
            private static void TagsChanged(object sender, DependencyPropertyChangedEventArgs e)
            {
                TagCloudControl tagCloudControl = sender as TagCloudControl;
                WeightToSizeConverter converter = tagCloudControl.FindResource("WeightToSizeConverter") as WeightToSizeConverter;
                if (converter != null && tagCloudControl.Tags != null)
                {
                    converter.MaxWeight = tagCloudControl.Tags.Max(t => t.Weight);
                }
            }
        }
    
        public class WeightToSizeConverter : IValueConverter
        {
            public int MaxWeight { get; set; }
    
            #region IValueConverter Members
            public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                int weight = (int)value;
                return 32 * MaxWeight / weight;
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                throw new NotImplementedException();
            }
            #endregion IValueConverter Members
        }
    }
