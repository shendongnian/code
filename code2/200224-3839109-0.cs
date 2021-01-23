    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    namespace Web
    {
        [    AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal), 
             AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal),
             ToolboxData("<{0}:CustomPanel runat=\"server\"> </{0}:CustomPanel>"),
    ]
        public class CustomPanel : CompositeControl
    {
            private Panel panelContainer;
            private CheckBox chkHideContent;
            private Panel panelInnerContainer;
            [Bindable(true),
            Category("Appearance"),
            DefaultValue(""),
            Description("The text to display with the checkbox.")]
            public string CheckBoxText
            {
                get
                {
                    EnsureChildControls();
                    return chkHideContent.Text;
                }
                set
                {
                    EnsureChildControls();
                    chkHideContent.Text = value;
                }
            }
            [Bindable(true)]
            [Category("Data")]
            [DefaultValue("")]
            [Localizable(true)]
            public bool IsCheckBoxChecked
            {
                get
                {
                    return chkHideContent.Checked;
                }
            }
            [Bindable(true)]
            [Category("Data")]
            [DefaultValue("")]
            [Localizable(true)]
            public bool HideInnerPanel
            {
                set
                {
                    EnsureChildControls();
                    panelInnerContainer.Visible = value;
                }
            }
            [Bindable(true)]
            [Category("Data")]
            [DefaultValue("")]
            [Localizable(true)]
            public ControlCollection InnerPanelControls
            {
                get
                {
                    EnsureChildControls();
                    return panelInnerContainer.Controls;
                }
            }
            protected virtual void OnCheckboxChanged(EventArgs e)
            {
                if (chkHideContent.Checked)
                {
                    panelInnerContainer.Visible = false;
                }
                else
                {
                    panelInnerContainer.Visible = true;
                }
            }
            private void _checkbox_checkChanged(object sender, EventArgs e)
            {
                OnCheckboxChanged(EventArgs.Empty);
            }
            protected override void RecreateChildControls()
            {
                EnsureChildControls();
            }
            protected override void CreateChildControls()
            {
                Controls.Clear();
                panelContainer = new Panel();
                panelContainer.ID = "panelContainer";
                chkHideContent = new CheckBox();
                chkHideContent.ID = "chkHideContent";
                chkHideContent.CheckedChanged += new EventHandler(_checkbox_checkChanged);
                chkHideContent.AutoPostBack = true;
                panelInnerContainer = new Panel();
                panelInnerContainer.ID = "panelInnerContainer";
                this.Controls.Add(panelContainer);
                this.Controls.Add(chkHideContent);
                this.Controls.Add(panelInnerContainer);
            }
            protected override void Render(HtmlTextWriter writer)
            {
                panelContainer.RenderBeginTag(writer);
                chkHideContent.RenderControl(writer);
                panelInnerContainer.RenderControl(writer);
                panelContainer.RenderEndTag(writer);
            }
        }
    }
