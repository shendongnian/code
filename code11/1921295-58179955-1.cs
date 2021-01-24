    foreach (AccessApi.Control control in ap.Forms[formName].Section[AccessApi.AcSection.acHeader].Controls)
    {
        Type t = control.GetType();
        if (t.Equals(typeof(AccessApi.LabelClass)))
        {
            AccessApi.Label label = (AccessApi.Label)control;
            logger.Info(label.Caption);
        }
    }
