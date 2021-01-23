    public class PageViewStateDatabaseStored : Page
    {
        protected override object LoadPageStateFromPersistenceMedium()
        {
            CiroLightLibrary.BLL.ViewState myViewState = new ViewState();
            if (Request["__DATABASE_VIEWSTATE"] != null)
            {
                myViewState.GUID = Request["__DATABASE_VIEWSTATE"].ToString();
                myViewState.Load();
            }
            LosFormatter myFormatter = new LosFormatter();
            return myFormatter.Deserialize(myViewState.Value);
        }
        protected override void SavePageStateToPersistenceMedium(object viewState)
        {
            CiroLightLibrary.BLL.ViewState myViewState = new ViewState();
            if (Request["__DATABASE_VIEWSTATE"] != null)
                myViewState.GUID = Request["__DATABASE_VIEWSTATE"].ToString();
            else
                myViewState.GUID = Guid.NewGuid().ToString();
            LosFormatter myFormatter = new LosFormatter();
            StringWriter myStringWriter = new StringWriter();
            myFormatter.Serialize(myStringWriter, viewState);
            myViewState.Value = myStringWriter.ToString();
            myViewState.Save();
            ScriptManager.RegisterHiddenField(this, "__DATABASE_VIEWSTATE", myViewState.GUID);
        }
    }
