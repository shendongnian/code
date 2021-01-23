    /// <summary>
    /// Just a dummy invisible form.
    /// </summary>
    private class DummyForm : Form
    {
        
        protected override void SetVisibleCore(bool value)
        {
            //just override here, make sure that the form will never become visible
            if (!IsHandleCreated)
            {
                CreateHandle();
            }
    
            value = false;
            base.SetVisibleCore(value);
        }
    }
