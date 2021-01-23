    using System;
    using System.ComponentModel;
    using System.Drawing;
    
    namespace ExciteEngine2.MainApplication.BaseUI {
    
      public partial class BaseCreateForm : BaseForm {
    
        public BaseCreateForm() {
          InitializeComponent();
          SetupLookAndFeelThings();
        }
    
        public void SetupLookAndFeelThings() {
          LabelHeader.Font = new Font(Font.FontFamily, 12.25F, Font.Style, Font.Unit, Font.GdiCharSet);
        }
    
        [Category("Appearance"), DisplayName("HeaderText"), DescriptionAttribute("Text of the form's header."), Browsable(true)]
        public String HeaderText {
          get {
            return LabelHeader.Text;
          }
          set {
            LabelHeader.Text = value;
          }
        }
    
        [Category("Appearance"), DisplayName("HeaderImage"),  DescriptionAttribute("Image of the form's header."), Browsable(true)]
        public Image HeaderImage {
          get {
            return PictureTitle.Image;
          }
          set {
            PictureTitle.Image = value;
          }
        }
    
        private void RadButtonCancel_Click(object sender, EventArgs e) {
          Close();
        }
    
      }
    }
