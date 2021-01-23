    public class MyDropDownList : DropDownList
    {
        public MyDropDownList() { Entity = new Entity(); }
        public Entity {get;set;}
        protected override void OnLoad(EventArgs e)
        {
            this.DataSource = Entity.GetCollection();
            this.DataBind();
        }
    }
