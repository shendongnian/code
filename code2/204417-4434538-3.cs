    public static void load(Page page, string pageFileName)
    {
        foreach (ConfiguracionElem elem in Configuracion.GetConfig(pageFileName).Tooltips)
        {
            WebControl ctrl = (WebControl)FindControlRecursive(page, elem.controlid);
            if (ctrl == null)
                throw new ControlNotFoundException("There's no control'"+elem.controlid+"'")
            else
            {
                ctrl.Attributes.Add("onmouseover","return overlib('"+elem.message+"');");
                ctrl.Attributes.Add("onmouseout","return nd();");
            }
        }
    }
