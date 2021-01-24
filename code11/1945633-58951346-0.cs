        <EjsGrid TValue="Order" ModelType="@Model" AllowPaging="true" ...>
        ...
       <GridColumns>
            <GridColumn>
                <Template>
                    <EjsDropDownList TValue="string" Placeholder="Select a Project">
                        <EjsDataManager Url="/Api/Default/GetProjectsList" Adaptor="Adaptors.WebApiAdaptor" CrossDomain=true></EjsDataManager>
                        <DropDownListFieldSettings Text="Item1" Value="Item2"></DropDownListFieldSettings>
                    </EjsDropDownList>
                </Template>
            </GridColumn>
            ...
        </GridColumns>
    </EjsGrid>
    
    @code{
    
        EjsButton accountButton;
        public Order Model = new Order();
        ...
    }
