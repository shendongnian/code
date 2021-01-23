    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    namespace MyExample.Web
    {
        public class MyDeleteButtonField : TemplateField
        {
            #region Properties
    
            private string _ConfirmText = "Delete Me?";
            public string ConfirmText
            {
                get { return _ConfirmText; }
                set { _ConfirmText = value; }
            }
    
            private string _ImageUrl = "~/Assets/Images/Buttons/flip.png";
            public string ImageUrl
            {
                get { return _ImageUrl; }
                set { _ImageUrl = value; }
            }
    
            #endregion
    
            #region Methods
    
            public override bool Initialize(bool sortingEnabled, System.Web.UI.Control control)
            {
                base.ItemTemplate = new MyTemplate(this.ConfirmText, this.ImageUrl);
                return base.Initialize(sortingEnabled, control);
            }
    
            #endregion
    
            #region Template
    
            public class MyTemplate : ITemplate
            {
                private string _ConfirmText;
                private string _ImageUrl;
    
                public MyTemplate(string confirmText, string imageUrl)
                {
                    _ConfirmText = confirmText;
                    _ImageUrl = imageUrl;
                }
    
                void ITemplate.InstantiateIn(Control container)
                {
                    ImageButton bt = new ImageButton();
                    bt.CommandName = "Delete";
                    bt.ImageUrl = _ImageUrl;
                    bt.ImageAlign = ImageAlign.AbsMiddle;
                    bt.AlternateText = "Delete Me";
                    bt.OnClientClick = String.Format("return confirm('{0}');", _ConfirmText);
                    container.Controls.Add(bt);
    
                }
            }
    
            #endregion
    
        }
    }
