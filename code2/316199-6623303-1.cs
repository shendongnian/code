    class Foo : IPagedList<Bar>
    {
        /* skipped : IPagedList<Bar> implementation */
        IEnumerable IPagedList.PageResults {
            get { return this.PageResults; } // re-use generic version
        }
        Type IPagedList.ElementType {
            get { return typeof(Bar); }
        }
    }
