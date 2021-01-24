        //avoid handling events this way; attach an event handler instead unless you specifically EE's to override the base onload 
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Task.Run(Proceso).Wait();
            this.Close();
        }
