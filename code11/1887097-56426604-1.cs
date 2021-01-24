    public class ApplicationForms : IApplicationForms {
        private readonly IEnumerable<IForms> forms;
        public ApplicationForms(IEnumerable<IForms> forms) {
            this.forms = forms;
        }
        public void SubmitApplicationForm(FormData data) {
            var form = forms.FirstOrDefault(_ => _.FormType == data.FormType);
            if(form != null)
                form.CreateNewForm(data);
            
            //...
        }
    }
    
