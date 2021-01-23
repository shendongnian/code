    public static string GetHtmlClass(DT_Control_Profile Pro)
    {
        String result = "";
        String[] cutsector = Pro.Job_Title.Split('/');
        foreach (string s in cutsector)
        {
            if (s.Trim().ToUpper() == "WELL ENGINEERING")
            {
                result += "sectorcon conwelleng ";
            }
            else if (s.Trim().ToUpper() == "RESEVOIR ENGINEERING")
            {
                result += "sectorcon conreseng ";
            }
            else if (s.Trim().ToUpper() == "GEO SCIENCES")
            {
                result += "sectorcon congeoscie ";
            }
            else if (s.Trim().ToUpper() == "FACILITES ENGINEERING")
            {
                result += "sectorcon confacilieng ";
            }
        }
    }
