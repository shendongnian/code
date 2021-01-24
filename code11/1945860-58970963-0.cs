    public async Task OnGetAsync(string sortOrder, string MinDate, string MaxDate)
            {
    
                if (MinDate!= null)
                {
                    this.MinDate = Convert.ToDateTime(MinDate);
                }
    
                if (MaxDate!= null)
                {
                    this.MaxDate = Convert.ToDateTime(MaxDate);
                }
            }
