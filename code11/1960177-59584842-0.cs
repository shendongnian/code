        @page  "/update-test"
    <EditForm Model="@Item">
        <div class="notifyParametersForm">
        </div>
        <div class="mailFrom">
            <label><strong>From:</strong></label>
            <InputText id="from" @bind-Value="Item.MAILFROM" placeholder="Enter New Mail From" />
        </div>
        <div class="mailTo">
            <label><strong>To:</strong></label>
            <InputText id="to" @bind-Value="Item.MAILTO" placeholder="Enter New Mail To" />
        </div>
        <div class="subject">
            <label id="subjectLabel"><strong>Subject:</strong></label>
            <InputText id="subject" @bind-Value="Item.EMAIL_SUBJECT" placeholder="Enter New Subject" />
        </div>
    
        <button class="btn btn-warning" @onclick="ResetInputs">Refresh</button>
    </EditForm>
    
    @code {
    
    
        EmailItem Item;
        protected override async Task OnInitializedAsync()
        {
            try
            {
                GetData();
                base.OnInitialized();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
    
        }
    
        protected void GetData()
        {
            Item = new EmailItem()
            {
                MAILFROM = "testfrom@test.com",
                MAILTO = "testto@test.com",
                EMAIL_SUBJECT = "subject",
            };
        }
    
        public void ResetInputs()
        {
            GetData();
        }
    
        public class EmailItem
        {
            public string MAILTO { get; set; }
            public string MAILFROM { get; set; }
            public string EMAIL_SUBJECT { get; set; }
        }
    }
