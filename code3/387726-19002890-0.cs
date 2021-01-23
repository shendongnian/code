    class UpdateableStringElement : StringElement
    {
        public UpdateableStringElement(string name): base (name)
        {
        }
        UILabel DetailText = null;
        public void UpdateValue(string text)
        {
            Value = text;
            if (DetailText != null)
                DetailText.Text = text;
        }
        public override UITableViewCell GetCell(UITableView tv)
        {
            var cell = base.GetCell(tv);
            DetailText = cell.DetailTextLabel;
            return cell;
        }
    }
