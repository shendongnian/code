    @page "/"
    @using Microsoft.AspNetCore.Components.Forms
    @using System.ComponentModel.DataAnnotations;
    <EditForm Model="@customer" OnSubmit="@submitChanges">
       <DataAnnotationsValidator />
       <p>
        <InputText id="name" @bind-Value="customer.Name" /><br />
        </p>
        @foreach (var phone in customer.phones)
       {
          <p>
            <InputText @bind-Value="phone.PhoneNumber" />
          </p>
       }
       <p>
        <button type="submit">submit</button>
       </p>
    </EditForm>
    <div>
        <p>Edit  customer</p>
        <p>@customer.Name</p>
        @foreach (var phone in customer.phones)
        {
            <p>@phone.PhoneNumber</p>
        }
      </div>
     
    @code {
        Customer customer;
        protected override void OnInitialized()
       {
           customer = new Customer();
       }
        private void submitChanges()
        {
           // _data.setCustomer(customer);
        }
        public class Customer
        {
           public string Name { get; set; } = "jeff";
           //[ValidateComplexType]
           public List<Phone> phones { get; } = new List<Phone>() { new Phone 
                                        {PhoneNumber = "123456" },
                                        new Phone {PhoneNumber = "654321" }};
        }
       public class Phone
      {
          public string PhoneNumber { get; set; }
       }
    }
