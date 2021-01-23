    public class YourTemplate: ITemplate
    {
        public void InstantiateIn(Control container)
        {
            Control userControl = container.Page.LoadControl("YourUserControl.ascx");
            container.Controls.Add(userControl);
        }
    }
