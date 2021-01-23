    List<string> days = GetDays();
    List<string> months = GetMonths();
    List<string> years = GetYears();
    
    Son1DDLDay.DataSource = days;
    Son1DDLDay.DataBind();
    Son1DDLMonth.DataSource = months;
    Son1DDLMonth.DataBind();
    Son1DDLYear.DataSource = years;
    Son1DDLYear.DataBind();
    
    Son2DDLDay.DataSource = days;
    Son2DDLDay.DataBind();
    Son2DDLMonth.DataSource = months;
    Son2DDLMonth.DataBind();
    Son2DDLYear.DataSource = years;
    Son2DDLYear.DataBind();
