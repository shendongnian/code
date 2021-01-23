    protected void Page_Load(object sender, EventArgs e)
            {
                //List item collection
                ListItemCollection listItemCollection = new ListItemCollection();
                listItemCollection.Add("Audi");
                listItemCollection.Add("BMW");
                listItemCollection.Add("Ford");
                listItemCollection.Add("Vauxhall");
                listItemCollection.Add("Volkswagen");
                CarDropDown.DataSource = listItemCollection;
                CarDropDown.DataBind();
    
                //Array
                string[] myCollect = { "Audi", "BMW", "Ford", "Vauxhall", "Volkswagen" };
                CarDropDown.DataSource = myCollect;
                CarDropDown.DataBind();
    
                //IList
                List<string> listCollection = new List<string>();
                listCollection.Add("Audi");
                listCollection.Add("BMW");
                listCollection.Add("Ford");
                listCollection.Add("Vauxhall");
                listCollection.Add("Volkswagen");
                CarDropDown.DataSource = listCollection.OrderBy(name => name);
                CarDropDown.DataBind();
            }
