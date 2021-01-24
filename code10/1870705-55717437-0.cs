    @using(Html.BeginForm( // your paramas ))
    {
        @if (Model.Phones.Count > 0)
            {
                foreach (var phone in Model.Phones)
                {
                 <p>
                    phone.PhoneType Phone: <span class="policy-bold">phone.PhoneNumber</span>
                </p>
                }
            }
            else
            {
                <p>Phone Number: <span class="policy-bold">N/A</span></p>
            }
        
    }
