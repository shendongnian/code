        private List<MyClass> MasterGridViewDataSource
        {
            get { return Session["MasterGridViewDataSource"] as List<MyClass>; }
            set { Session["MasterGridViewDataSource"] = value; }
        }
        private List<int> SelectedIDs
        {
            get { return ViewState["SelectedIDs"] as List<int>; }
            set { ViewState["SelectedIDs"] = value; }
        }
        protected void Page_Init(object sender, EventArgs e)
        {
            MasterGridView.SelectedIndexChanged += MasterGridView_OnSelectedIndexChanged;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var masterGridDataSource = GetMasterGridDataSource();
                MasterGridViewDataSource = masterGridDataSource;
                MasterGridView.DataSource = masterGridDataSource;
                MasterGridView.DataBind();
                SelectedIDs = new List<int>();
            }
        }
        private List<MyClass> GetMasterGridDataSource()
        {
            return (from item in Enumerable.Range(1, 10)
                    select new MyClass { Id = item, Name = string.Format("Item #{0}", item), Age = item })
                    .ToList();
        }
        void MasterGridView_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedId = (int)MasterGridView.SelectedDataKey.Value;
            if (!SelectedIDs.Contains(selectedId))
                SelectedIDs.Add(selectedId);
            DetailsGridView.DataSource = (from item in MasterGridViewDataSource
                                          join id in SelectedIDs on item.Id equals id
                                          select item);
            DetailsGridView.DataBind();
        }
        [Serializable]
        public class MyClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
