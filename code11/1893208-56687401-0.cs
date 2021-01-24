        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(ConvertAsync));
        }
    
        public async Task ConvertAsync()
        {
            var convertApi = new ConvertApi("<secret>");
            var convertApiResponse = await convertApi.ConvertAsync("docx", "pdf", new ConvertApiFileParam(@"C:\TestFiles\test3.docx"));
            convertApiResponse.SaveFiles(@"C:\TestFiles");
        }
