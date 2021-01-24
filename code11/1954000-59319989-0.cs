    // in MyObj
    public MyObj WithSections(IEnumerable<Section> sections) =>
        new MyObj {
            Title = this.Title,
            Sections = sections
        };
    // in Section
    public Section WithItems(IEnumerable<Items> items) =>
        new Section {
            Title = this.Title,
            Items = items,
            SortOrder = this.SortOrder
        };
