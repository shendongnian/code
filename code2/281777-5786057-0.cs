    public class MyTemplate : ITemplate
    {
        #region ITemplate Members
    
        public void InstantiateIn(Control container)
        {
            CheckBox chk = new CheckBox();
            chk.ID = "chk";
            container.Controls.Add(chk);
        }
    
        #endregion
    }
