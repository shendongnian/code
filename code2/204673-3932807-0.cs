    public class UnitTemplate : ITemplate {
        public string UnitTemplateID { get; set; }
        string ITemplate.TemplateId { get { return UnitTemplateID; } }
    }
    public class QualTemplate : ITemplate
    {
        public string QualTemplateID { get; set; }
        string ITemplate.TemplateId { get { return QualTemplateID; } }
    }
