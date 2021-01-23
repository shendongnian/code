        protected void Page_Load(object sender, EventArgs e)
        {
        	var cb= FindControlByAttribute<CheckBox>(this.Page, "attr-ID", "111");
        }
        public T FindControlByAttribute<T>(Control ctl, string attributeName, string attributeValue) where T : WebControl
        {
        	foreach (Control c in ctl.Controls)
        	{
        		if (c.GetType() == typeof(T) && ((T)c).Attributes[attributeName]==attributeValue)
        		{
        			return (T) c;
        		}
        		var cb= FindControlByAttribute<T>(c, attributeName, attributeValue);
        		if (cb != null)
        			return cb;
        	}
        	return null;
        }
