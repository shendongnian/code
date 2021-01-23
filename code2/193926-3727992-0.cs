    public override object Clone() {
        MyDataGridViewColumn that = (MyDataGridViewColumn)base.Clone();
        that.MaxLength = this.MaxLength;
        return that;
    }
