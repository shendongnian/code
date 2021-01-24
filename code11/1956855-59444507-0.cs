    <select value="@SelectedYear" @onchange="ChangeYear">
        @for (int i = 2015; i < DateTime.Now.Year + 1; i++)
        {
            <option value="@i">@i</option>
        }
    </select>
    
    <p>@SelectedYear</p>
    
    @code
     {
        private int SelectedYear { get; set; } = 2018;
    
        void ChangeYear(ChangeEventArgs e)
        {
            SelectedYear = Convert.ToInt32(e.Value.ToString());
    
        }
    }
