        protected void Page_Load(object sender, EventArgs e)
        {
            bool a = true;
            bool b = false;
            bool isValid = A() & B();
            Response.Output.Write("<br>Is Valid {0}", isValid);
        }
        bool A()
        {
            Response.Write("<br>TestA");
            return false;
        }
        bool B()
        {
            Response.Write("<br>TestB");
            return true;
        }
