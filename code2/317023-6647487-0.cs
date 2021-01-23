            TextBox tb = sender as TextBox;
            if (tb == null)
                return;
            tb.PreviewTextInput -= tbb_PreviewTextInput;
            DataObject.RemovePastingHandler(tb, OnClipboardPaste);
            bool b = ((e.NewValue != null && e.NewValue.GetType() == typeof(bool))) ?
                (bool)e.NewValue : false;
            if (b)
            {
                tb.PreviewTextInput += tbb_PreviewTextInput;
                DataObject.AddPastingHandler(tb, OnClipboardPaste);
            }
