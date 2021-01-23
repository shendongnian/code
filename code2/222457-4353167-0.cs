      public enum TextDataFormat
    {
        // Summary:
        //     Specifies that the text data is in the System.Windows.DataFormats.Text data
        //     format.
        Text = 0,
        //
        // Summary:
        //     Specifies that the text data is in the System.Windows.DataFormats.UnicodeText
        //     data format.
        UnicodeText = 1,
        //
        // Summary:
        //     Specifies that the text data is in the System.Windows.DataFormats.Rtf data
        //     format.
        Rtf = 2,
        //
        // Summary:
        //     Specifies that the text data is in the System.Windows.DataFormats.Html data
        //     format.
        Html = 3,
        //
        // Summary:
        //     Specifies that the text data is in the System.Windows.DataFormats.CommaSeparatedValue
        //     data format.
        CommaSeparatedValue = 4,
        //
        // Summary:
        //     Specifies that the text data is in the System.Windows.DataFormats.Xaml data
        //     format.
        Xaml = 5,
    }
    so if you know that data format is Text tha n
    string text = ClipBoard.GetText(TextDataFormats.Text);
