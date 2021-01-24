    public class Project
    {
        [Required]
        public string ProjectTitle { get; set; }
        [Required]
        public string ProjectDescriptionShort { get; set; }
        [Required]
        public string ProjectDescriptionFull { get; set; }
        [Required]
        public int ProjectTypeId { get; set; }
        public IEnumerable<SelectListItem> ProjectTypes
        {
            get
            {
                Datas.DataSetProject.tbProjectTypeDataTable tbProjectTypes = new Datas.DataSetProjectTableAdapters.tbProjectTypeTableAdapter().GetData();
                List<SelectListItem> Items = new List<SelectListItem>();
                foreach(Datas.DataSetProject.tbProjectTypeRow row in tbProjectTypes)
                {
                    Items.Add(new SelectListItem()
                    {
                        Value = row.Id.ToString(),
                        Text = row.ProjectName
                    });
                }
                return Items;
            }
            set { }
        }
        public List<Skill> Skills
        {
            get
            {
                Datas.DataSetProject.tbSkillDataTable tbSkills = new Datas.DataSetProjectTableAdapters.tbSkillTableAdapter().GetData();
                List<Skill> Items = new List<Skill>();
                foreach (Datas.DataSetProject.tbSkillRow row in tbSkills)
                {
                    Items.Add(new Skill()
                    {
                        SkillId = row.Id,
                        SkillName = row.SkillNumber + " - " + row.SkillName,
                        SkillNumber = row.SkillNumber
                    });
                }
                return Items;
            }
            set { }
        }
    }
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public string SkillNumber { get; set; }
        public bool IsChecked { get; set; }
        public HttpPostedFileBase files { get; set; }
    }
