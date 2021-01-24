    public class Service
    {
        private readonly IWizard _wizard;
        public Service(IWizard wizard)
        {
            _wizard = wizard;
        }
        public bool DoSomething(SpellBase spell)
        {
            return _wizard.Cast(spell);
        }
    }'
