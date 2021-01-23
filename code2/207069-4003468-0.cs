        protected override void OnInit(EventArgs e)
        {
            TemplatedWizardStep templatedWizardStep = 
                new TemplatedWizardStep { Title = "Lalalal" };
            //  load control by path to initialize markup
            ITemplate control = (ITemplate)Page.LoadControl("\\Step1UserControl.ascx");                        
            
            templatedWizardStep.ContentTemplate = control;            
            wizard.WizardSteps.Add(templatedWizardStep);
            
            //  make it visible
            wizard.MoveTo(templatedWizardStep);
            base.OnInit(e);   
        }
