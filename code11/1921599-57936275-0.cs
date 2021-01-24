    @page "/FormsValidation"
    @using BlazorListPreview9.Model;
    
    <EditForm EditContext="@editContext" OnValidSubmit="@HandleValidSubmit">
        <DataAnnotationsValidator />
        <ValidationSummary />
    
        <InputText id="name" @bind-Value="@itemModel.Name" />
        <button type="submit">Submit</button>
    </EditForm>
    
    @code {
        private EditContext editContext;
    
        private ItemModel itemModel = new ItemModel();
    
         protected override void OnInitialized()
      {
        this.editContext = new EditContext(itemModel );
       
        private void HandleValidSubmit()
        {
            Console.WriteLine("OnValidSubmit");
        }
    }
