    public string GeneratePatientNumber()
    {
        return string.Join(
            "-", 
            Convert.ToString(GetCurrentDate()), 
            GetGenderCode().ToString(),
            RadomNum().ToString());
    }
