    public class DepartmentReportPage : Page
    {
        private readonly DepartmentReportPresenter _presenter;
        public DepartmentReportPage()
        {
            this._presenter =
                UnityLocator.GetInstance<DepartmentReportPresenter>();
            this._presenter.View = this;
        }
    }
