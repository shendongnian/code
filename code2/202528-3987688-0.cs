    public class RequestForm
    {
        public string Name { get; set; }
        public string ControlID { get; set; }
        public string StepID { get; set; }
        public string FilePath { get; set; }
        public string Emails { get; set; }
        public string Results { get; set; }
        public int Position { get; set; }
        public bool Visible { get; set; }
        /// <summary>
        /// FormResults gathers all needed information about the forms
        /// </summary>
        /// <param name="formName">Name of the Form</param>
        /// <param name="formControlID">ID of the User Control </param>
        /// <param name="wizardStepID">ID of the Wizard Step</param>
        /// <param name="formFilePath">File path of the physical form</param>
        /// <param name="formResults">Results from the form</param>
        /// <param name="formEmails">Other emails to include</param>
        public RequestForm(string formName, string formControlId, string wizardStepID, int wizardStepPosition, string formFilePath, string formEmails,string formResults, bool formVisible = false)
        {
            this.Name = formName;
            this.ControlID = formControlId;
            this.StepID = wizardStepID;
            this.Position = wizardStepPosition;
            this.FilePath = formFilePath;
            this.Emails = formEmails;
            this.Results = formResults;
            this.Visible = formVisible;
        }
    }
