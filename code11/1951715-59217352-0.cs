    <fieldset class="group">
            <legend>Month</legend>
            <ul class="checkbox-grid">
                <li>                
                    <InputCheckbox @bind-Value="Months[0].IsMonthChecked" @onclick="() => CheckAllMonths(Months[0])"/>
                    <label for="@Months[0].MonthId" id="checkboxLabel">@Months[0].MonthName</label>
                </li>            
            </ul>        
            @{ 
                for(var i = 1; i < Months.Count(); i++)
                {
                    var j = i;
                    <ul class="checkbox-grid">
                        <li>
                            <InputCheckbox @bind-Value="Months[j].IsMonthChecked" @onclick="() => CheckManualMonth(Months[j])"/>                        
                            <label for="@Months[j].MonthId" id="checkboxLabel">@Months[j].MonthName</label>
                        </li>
                    </ul>
                }
            }        
        </fieldset>
    
    void CheckAllMonths(Month month)
        {
            if(month.IsMonthChecked == false)
            {
                foreach(var item in Months)
                {
                    item.IsMonthChecked = true;
                }
            }
            else
            {
                foreach(var item in Months)
                {
                    item.IsMonthChecked = false;
                }
            }
        }
    
        void CheckManualMonth(Month month)
        {
            if(month.IsMonthChecked == false)
            {
                month.IsMonthChecked = true;
            }
            else
            {
                month.IsMonthChecked = false;
                Months[0].IsMonthChecked = false;
            }
        }
