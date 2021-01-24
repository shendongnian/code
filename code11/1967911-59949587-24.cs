    public partial class UCModule2: UserControl
    {
        List<Form> formsCollection = null;
        public UCModule2()
        {
            InitializeComponent();
            formsCollection = new List<Form>();
        }
        private Type FormType { get; set; }
        // Check whether the new type is different before setting the property,
        // in case the FormType property has an explicit setter.
        public void SetForm(Type formType)
        {
            if (this.FormType != formType) {
                this.FormType = formType;
            }
        }
        public void CloseAllForms()
        {
            if (formsCollection != null && formsCollection.Count > 0) {
                for (int i = formsCollection.Count - 1; i >= 0 ; i--) {
                    formsCollection[i].Dispose();
                }
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            CloseAllForms();
            base.OnHandleDestroyed(e);
        }
        private void btnShowForm_Click(object sender, EventArgs e)
        {
            if (FormType == null) return;
            var instance = (Form)Activator.CreateInstance(FormType);
            formsCollection.Add(instance);
            instance.Show();
        }
