    public class MockTestControllerRunner : IRunner<Interfaces.ActionSettings>
    {
        #region IRunner<T> Members
        public ActionSettings Run(string runnerXml)
        {
            MvcActionSettings mvcActionSettings = XmlSerialiser.XmlDeserialise<MvcActionSettings>(runnerXml);
            IMvcActionSettingsCreator creator = new MockPassThroughActionSettingsGenerator();
            Interfaces.ActionSettings v = creator.Create(mvcActionSettings);
            return v;
        }
        #endregion
        #region IRunnerWorkflowSubscriber Members
        public void Initialise(IWizardManagerBase manager)
        {
            
        }
        #endregion
    }
