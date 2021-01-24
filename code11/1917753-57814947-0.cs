    // add project assembly reference: System.Design
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System;
    using System.Windows.Forms.Design;
    
    public class SingleLineTB : TextBox
    {
        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false)]
        public override bool Multiline
        {
            get {return base.Multiline;}
            set {}
        }
    
        #region Designer Services
        private IDesignerHost designerHost;
    
        public override ISite Site
        {
            get {return base.Site;}
            set 
            {
                base.Site = value;
                if (value == null)
                {
                    // this instance is being removed from the design surface
                    DetachDesignerServices();
                }
                else // being added to the design surface
                {
                    designerHost = (IDesignerHost)value.GetService(typeof(IDesignerHost));
                    if (designerHost != null)
                    {
                        if (designerHost.Loading)
                        {
                            // the designer has not finished loading, 
                            // postpone all other connections until it has finished loading
                            designerHost.LoadComplete += DesignerHostLoaded;
                        }
                        else
                        {
                            if (designerHost.InTransaction)
                            {
                                // designerHost loaded, but is in the in the process of creating this instance
                                designerHost.TransactionClosed += DesignerTransactionClosed;
                            }
                            else
                            {
                                // this will probably never be hit as the designer
                                // should be siting the component in a transaction
                                ClearDesignerActionLists();
                            }
                        }
                    }
                }
            }
        }
    
        private void DesignerHostLoaded(object sender, EventArgs e)
        {
            designerHost.LoadComplete -= DesignerHostLoaded;
            ClearDesignerActionLists();
        }
    
        private void DesignerTransactionClosed(object sender, DesignerTransactionCloseEventArgs e)
        {
            designerHost.TransactionClosed -= DesignerTransactionClosed;
            ClearDesignerActionLists();
        }
        private void DetachDesignerServices()
        {
            if (designerHost != null)
            {
                designerHost.TransactionClosed -= DesignerTransactionClosed;
                designerHost.LoadComplete -= DesignerHostLoaded;
                designerHost = null;
            }
        }
    
        private void ClearDesignerActionLists()
        {
            ControlDesigner myDesigner = designerHost.GetDesigner(this) as ControlDesigner;
            myDesigner?.ActionLists.Clear();
        }
    
        #endregion // "Designer Services
    }
