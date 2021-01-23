    interface IPageView {
        IPager Pager {get;set;}
        void ShowPage(PageData pageData);
    }
    // This is your custom control:
    class PageViewControl : Control, IPageView {
        public IPager Pager { get; set; }
        public void ShowPage(PageData pageData) {
            // show the page data
        }
    }
    // You've already defined the IPager interface:
    interface IPager {
        ... 
    }
    class Pager : IPager {
        IPageView _view;
        public void SetView(IPageView view) { _view = view; }
        ... // state members, etc
        public void NextPage() {
            // update state, find page data
            _view.ShowPage(pageData);
        }
    }
