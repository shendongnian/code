    public class MyPreferences
    {
        [XmlElement(ElementName="GeneratorPreferences")]
        public TemplateGeneratorPreferences FormSpecificPref { get; set; }
        public MyPreferences()
        {
            FormSpecificPref = new TemplateGeneratorPreferences();
        }
    }
    public class TemplateGeneratorPreferences
    {
        [XmlAttribute("MyBool")]
        public bool MyBool { get; set; }
        public TemplateGeneratorPreferences()
        {
            MyBool = true;
        }
    }
