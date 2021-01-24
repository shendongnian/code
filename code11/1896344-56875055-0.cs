             private void applyMyFonts()
        {
                string TextOut;
                MyRichEditBox.Document.GetText(TextGetOptions.None, out TextOut);
                MyRichEditBox.Document.Selection.SetRange(0, TextOut.Length);
        MyRichEditBox.Document.Selection.CharacterFormat.Name = "Assets/Fonts/MyFont.ttf#MyFont";   
        }
    private async void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            Windows.Storage.Pickers.FileOpenPicker open =
               new Windows.Storage.Pickers.FileOpenPicker();
            open.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.DocumentsLibrary;
            open.FileTypeFilter.Add(".rtf");
            Windows.Storage.StorageFile file = await open.PickSingleFileAsync();
            if (file != null)
            {
                try
                {
                    Windows.Storage.Streams.IRandomAccessStream randAccStream =
                await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                    // Load the file into the Document property of the RichEditBox.
                    MyRichEditBox.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.FormatRtf, randAccStream);
                }
                catch (Exception)
                {
                    ContentDialog errorDialog = new ContentDialog()
                    {
                        Title = "File open error",
                        Content = "Sorry, I couldn't open the file.",
                        PrimaryButtonText = "Ok"
                    };
                    await errorDialog.ShowAsync();
                }
            }
            applyMyfonts();
    }
                     
