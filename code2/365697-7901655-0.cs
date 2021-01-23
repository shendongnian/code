    public interface IElement
    {
        string RenderStart();
        string RenderEnd();
        string Render();
        IList<IElement> Children { get; }
        void LoadFromXML(XmLReader reader);
    }  // eo interface IElement
    public abstract class Element : IElement
    {
        List<IElement> children_ = new List<IElement>();
        public List<IElement> Children { get { return children_; } }
        public string Render()
        {
            StringBuilder builder = new StringBuilder(RenderStartTag());
            foreach(IElement e in children_)
                builder.Append(e.Render());
            builder.Append(RenderEndTag());
            return builder.ToString();
        }
    }  // eo class Element
    public class FieldSetElement : Element
    {
        public string RenderStart()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("<fieldset legend=\"")
                   .Append("\">");
            return builder.ToString();
        }
        public string RenderEnd()
        {
            return ("</fieldset>");
        }
        public string Legend {get; set; }
        public void LoadFromXml(XmlReader reader)
        {
            Legend = reader.GetAttribute("legend");
        } // eo LoadFromXml
    }  // eo class FieldSet
