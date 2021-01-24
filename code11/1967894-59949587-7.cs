    public partial class UCModule2: UserControl
    {
        public Form FormInstance { get; private set; }
         
        public Form SetForm(Type formType)
        {
            if (this.FormInstance == null) {
                this.FormInstance = (Form)Activator.CreateInstance(formType);
            }
            return this.FormInstance;
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.FormInstance?.Show();
        }
    }
