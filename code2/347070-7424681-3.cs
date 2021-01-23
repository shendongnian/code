    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;
    using HtmlAgilityPack;
    public class HtmlControlFromString : Literal
    {
        private HtmlDocument _document = new HtmlDocument();
        private HtmlNode _htmlElement;
        public AttributesCollection Attributes { get; set; }
        public HtmlControlFromString(string html)
        {
            _document.LoadHtml(html);
            if (_document.DocumentNode.ChildNodes.Count > 0)
            {
                _htmlElement = _document.DocumentNode.ChildNodes[0];
                Attributes = new AttributesCollection(_htmlElement);
                Attributes.AttributeChanged += new EventHandler(Attributes_AttributeChanged);
                SetHtml();
            }
            else
            {
                throw new InvalidOperationException("Argument does not contain a valid html element.");
            }
        }
        void Attributes_AttributeChanged(object sender, EventArgs e)
        {
            SetHtml();
        }
        void SetHtml()
        {
            Text = _htmlElement.OuterHtml;
        }
    }
    public class AttributesCollection
    {
        public event EventHandler AttributeChanged;
        private HtmlNode _htmlElement;
        public string this[string attribute]
        {
            get
            {
                HtmlAttribute htmlAttribute = _htmlElement.Attributes[attribute];
                return htmlAttribute == null ? null : htmlAttribute.Value;
            }
            set
            {
                HtmlAttribute htmlAttribute = _htmlElement.Attributes[attribute];
                if (htmlAttribute == null)
                {
                    htmlAttribute = _htmlElement.OwnerDocument.CreateAttribute(attribute);
                    htmlAttribute.Value = value;
                    _htmlElement.Attributes.Add(htmlAttribute);
                }
                else
                {
                    htmlAttribute.Value = value;
                }
                EventHandler attributeChangedHandler = AttributeChanged;
                if (attributeChangedHandler != null)
                    attributeChangedHandler(this, new EventArgs());
            }
        }
        public AttributesCollection(HtmlNode htmlElement)
        {
            _htmlElement = htmlElement;
        }
    }
