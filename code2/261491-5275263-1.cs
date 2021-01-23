    public string DueDateCss
        {
            get
            {
                if(DueDate < DateTime.Now.AddMonths(-1)) return "Color1"; //witch is less than a month
                if(DueDate < DateTime.Now.AddMonths(-3)) return "Color2"; //witch is less than 3 months
                if(DueDate < DateTime.Now.AddMonths(-6)) return "Color3"; //witch is less than 6 months
                return  "";
            }
        }
