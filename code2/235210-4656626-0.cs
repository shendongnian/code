        protected override object SaveControlState()
        {
            object[] ControlStateData = new object[];
            //save your data like  ControlStateData[0] = ActivePage;
            return ControlStateData;
        }
        protected override void LoadControlState(object savedState)
        {
            object[] ControlStateData = savedState as object[];
            //Load your data like ActivePage = (int) ControlStateData[0];
            base.LoadControlState(ControlStateData[2]);
        }
        //Dont forget to add this procedure
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Page.RegisterRequiresControlState(this);
        }
