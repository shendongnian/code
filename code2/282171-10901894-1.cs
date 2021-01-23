    public static readonly DependencyProperty 
            NoteProperty = DependencyProperty.Register("Note",
            typeof(int), typeof(PatchRenderer),
            new PropertyMetadata(
                new PropertyChangedCallback(PatchRenderer.onNoteChanged)
                ));
        private static void onNoteChanged(DependencyObject d,
                   DependencyPropertyChangedEventArgs e)
        {
            // this is the bug: calling the setter in the callback
            //((PatchRenderer)d).Note = (int)e.NewValue;
            // the following was wrongly placed in the Note setter.
            // it make sence to put it here.
            // this method is intended to display stars icons
            // to represent the Note
            ((PatchRenderer)d).UpdateNoteIcons();
        }
