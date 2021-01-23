     public override object EditValue(ITypeDescriptorContext context, System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
            OptoSigmaLinearSettings opto = value as OptoSigmaLinearSettings;
            opto = (OptoSigmaLinearSettings)value;
            if (opto == null)
            {
                opto = new OptoSigmaLinearSettings();
            }
            if (service != null)
            {
                using (OptoSigmaLinearSetup form = new OptoSigmaLinearSetup(opto))
                {
                    DialogResult result;
                    result = service.ShowDialog(form);
                    if (result == DialogResult.OK)
                    {
                        opto = form.GeneralSettings;
                        
                    }
                }
            }
            return opto;
        }
