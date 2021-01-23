    public string DateCol1Css
        {
            get
            {
                if(DateCol1 < DateTime.Now.AddMonths(-1)) return "Color1"; //witch is less than a month
                if(DateCol1 < DateTime.Now.AddMonths(-3)) return "Color2"; //witch is less than 3 months
                if(DateCol1 < DateTime.Now.AddMonths(-6)) return "Color3"; //witch is less than 6 months
                return  "";
            }
        }
        public string DateCol2Css
        {
            get
            {
                if (DateCol2 < DateTime.Now.AddDays(-10)) return "Color1"; //witch is less than 10 days
                if (DateCol2 < DateTime.Now.AddDays(-30)) return "Color2"; //witch is less than 30 days
                return "";
            }
        }
        public string DateCol3Css
        {
            get
            {
                if (DateCol3 < DateTime.Now.AddMonths(-1)) return "Color1"; //witch is less than a month
                if (DateCol3 < DateTime.Now.AddMonths(-3)) return "Color2"; //witch is less than 3 months
                if (DateCol3 < DateTime.Now.AddMonths(-6)) return "Color3"; //witch is less than 6 months
                return "";
            }
        }
