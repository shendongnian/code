cs
    public static class SharedViewStateExtension
    {
        public static StateBag GetProtectedViewState(this Page page)
        {
            var viewStateField = typeof(Page).GetProperty("ViewState", BindingFlags.NonPublic | BindingFlags.Instance);
            return (StateBag) viewStateField.GetValue(page);
        }
    }
Of course, whatever you put into ViewState must be serializable, and I couldn't do that. So I stored the EditableLabels in a session-level dictionary where the key is a GUID saved in the ViewState.
The second problem, is that the `ControlFromPriviousPageLoad != ControlFromNextPageLoad`. New components get generate for each page load. Instead, I resort to comparing the IDs which are supposed to be unique for each page anyways.
I know that all of this sounds icky but ASP.NET is disgusting so lets just leave at that.
Resulting class: https://paste.rs/9bU.cs
