        protected override void  OnInit(EventArgs e)
        {
            View view1 = new View();
            View view2 = new View();
            View view3 = new View();
            Label l1 = new Label();
            Label l2 = new Label();
            Label l3 = new Label();
            l1.Text = "1";
            l2.Text = "2";
            l3.Text = "3";
            view1.Controls.Add(l1);
            view2.Controls.Add(l2);
            view3.Controls.Add(l3);
            MultiView1.Views.Add(view1);
            MultiView1.Views.Add(view2);
            MultiView1.Views.Add(view3);
            MultiView1.ActiveViewIndex = 0;
            base.OnInit();
        }
    
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex++;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex--;
        }
