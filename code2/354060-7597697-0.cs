    public class DepartmentReportPage : Page
    {
        this._presenter;
        public DepartmentReportPage()
        {
            this._presenter =
                UnityLocator.GetInstance<DepartmentReportPresenter>();
            this._presenter.View = this;
        }
    }
