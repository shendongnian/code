    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        this.PreLoad += (sender, args) =>
                            {
                                this.ClientScript.GetPostBackEventReference(this, "arg");
                                if (!IsPostBack) { return; }
                                string __targetaction = this.Request["__EVENTTARGET"];
                                string __args = this.Request["__EVENTARGUMENT"];
                                if (string.IsNullOrEmpty(__args)) return;
                                if (__targetaction == "leaving")
                                {
                                    doSomething();
                                }
                            };
    }
