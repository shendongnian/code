    public void RemoveEmptyChildren() {
         _ParentDetail.RemoveAll(
             x => x.Text == null ||
             string.IsNullOrEmpty(x.Text.TextWithHtml));
    }
