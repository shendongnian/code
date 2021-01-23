    using System.Collections.Generic;
    using System.Windows.Documents;
    using System.Windows.Controls;
    
    using GalaSoft.MvvmLight.Command;
    
    namespace Converters
    {
        public class MyInlineConverter
        {
            public RelayCommand<TextBlock> ConvertTextToInlinesCommand { get; private set; }
    
            public MyInlineConverter()
            {
                ConvertTextToInlinesCommand = new RelayCommand<TextBlock>(textBlock => convertTextToInlines(textBlock));
            }
    
            private static void convertTextToInlines(TextBlock textBlock)
            {
                foreach (Run run in textToInlines(textBlock.Text))
                    textBlock.Inlines.Add(run);
            }
    
            private static IEnumerable<Run> textToInlines(string text)
            {
                List<Run> retval = new List<Run>();
                // Perform your conversion here.
                return retval;
            }
        }
    }
