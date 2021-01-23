    public class RelayObject : ICantThinkOfAGoodName
    {
        public RelayObject() : this(null, null) {}
        public RelayObject(Func<string, bool> canEdit, Func<string, bool> canDelete)
        {
            if(canEdit == null) canEdit = s => true;
            if(canDelete == null) canDelete = s => true;
            _canEdit = canEdit;
            _canDelete = canDelete;
        }
        public bool CanEdit(string item)
        {
            return _canEdit(item);
        }
        public bool CanDelete(string item)
        {
            return _canDelete(item);
        }
    }
