        public int MaxRequestLengthInMB
        {
            get
            {
                return (Context.ApplicationInstance as Global).MaxRequestLengthInMB;
            }
        }
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CheckMaxFileSizeErr();
        }
        private void CheckMaxFileSizeErr()
        {
            string key = Global.MAXFILESIZEERR;
            bool isMaxFileSizeErr = (bool)(Context.Items[key] ?? false);
            if (isMaxFileSizeErr)
            {
                string script = String.Format("alert('Max file size exceeded. Uploads are limited to approximately {0} MB.');", MaxRequestLengthInMB);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), key, script, true);
            }
        }
