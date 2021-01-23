     public partial class BaseForm : Form
     {
        protected override void OnLoad(EventArgs e)
        {
           Color colBackColor =Properties.Settings.Default.FormsBackgroundColor;
           BackColor = colBackColor;
        }
      }
