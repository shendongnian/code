    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.ComponentModel;
    
    namespace CSBSSWControls
    {
        // Class inhertis TabControl
        public class bssTabControl : TabControl
        {
            private bool AutoTab_;
            [DefaultValue(false)]
            public bool AutoTab { get { return AutoTab_; } set { AutoTab_ = value; } }
            protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                //property which determines auto change tabpages
                if (AutoTab)
                {
                    switch (keyData)
                    {
                        case Keys.Tab | Keys.Shift:
                            {
                                return SetNextTab(false);
                            }
                        case Keys.Tab:
                            {
                                return SetNextTab(true);
                            }
                    }
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            private bool SetNextTab(bool Forward)
            {
                // getting cuurent active control
                ContainerControl CC = this.FindForm();
                Control ActC = null;
                while (CC != null)
                {
                    ActC = CC.ActiveControl;
                    CC = ActC as ContainerControl;
                }
                //checking, current control should not be tabcontrol or tabpage
                if (ActC != null && !(ActC is TabPage) && !(ActC is bssTabControl))
                {
                    //getting current controls next control if it is tab page then current control is surely that last control on that tab page
                    //if shift+tab pressed then checked its previous control, if it is tab page then current control is first control on the current tab page.
                    TabPage NC = ActC.FindForm().GetNextControl(ActC, Forward) as TabPage;
                    if (NC != null)
                        if (this.TabPages.Contains(NC))
                            if (Forward)
                            {
                                //selecting next tab page
                                this.SelectedTab = NC;
                                return true;
                            }
                            else
                            {
                                if (this.TabPages.IndexOf(NC) > 0)
                                {
                                    //selecting pervious tab page
                                    this.SelectedIndex = this.TabPages.IndexOf(NC) - 1;
                                    return true;
                                }
                            }
                }
                return false;
            }
        }
    }
