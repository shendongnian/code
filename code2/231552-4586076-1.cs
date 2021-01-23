    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            CreateUserWizard createUserWizard = new CreateUserWizard();
            /* Difference Starts Here */
            CreateUserWizardStep createUserWizardStep = new CreateUserWizardStep();
            createUserWizardStep.ContentTemplate = new Template();
            createUserWizard.WizardSteps.Add(createUserWizardStep);
            /* End Difference */
            Panel1.Controls.Add(createUserWizard);
        }
    }
    public class Template : ITemplate
    {
        void ITemplate.InstantiateIn(Control container)
        {
            container.Controls.Add(new TextBox() { ID = "UserName" });
            container.Controls.Add(new TextBox() { ID = "Password" });
            container.Controls.Add(new TextBox() { ID = "Question" });
            container.Controls.Add(new TextBox() { ID = "Answer" });
            container.Controls.Add(new TextBox() { ID = "ConfirmPassword" });
            container.Controls.Add(new TextBox() { ID = "Email" });
            container.Controls.Add(new PlaceHolder() { ID = "ErrorMessage" });
        }
    }
