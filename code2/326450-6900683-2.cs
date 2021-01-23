    public class YourPresenter:Presenter<IAdministrarUsuariosView>
    {
    
        public YourPresenter(IAdministrarUsuariosView view) : base(view)
        {
        }
    
        protected override void OnViewLoad(object sender, EventArgs e)
        {
            List<TestItem> listResult = GetListItem();
            this.View.SetComboBox = listResult;
            this.View.SetGridView = listResult;
        }
    }
