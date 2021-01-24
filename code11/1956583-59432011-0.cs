    [XmlRoot]
    public class Hospitalization
    {
        public string PatientName { get; set; }
        public DateTime AdmitDate { get; set; }
        [XmlIgnore]
        public List<DiagnosisCode> ActiveDiagnoses { get; set; }
        [XmlElement("DiagnosisCode")]
        public List<DiagnosisCode> SerializableDiagnoses { get { return ActiveDiagnoses.Where(d => d.Order <= 2).ToList(); } }
    }
