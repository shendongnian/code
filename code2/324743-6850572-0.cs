    public class Vendor
    {
        public int VendorID { get; set; }
        public string VendorName { get; set; }
        [NotMapped]
        public IEnumerable<Questionnaire> OpenQuestionnaires
        {
            get { return Questionnaires.Where(q => q.IsActive); }
        }
        [NotMapped]
        public IEnumerable<Questionnaire> SubmittedQuestionnaires
        {
            get { return Questionnaires.Where(q => !q.IsActive); }
        }
        public virtual ICollection<Questionnaire> Questionnaires { get; set; }
        public virtual ICollection<QuestionnaireUser> QuestionnaireUsers { get; set; }
    }
