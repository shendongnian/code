    // Converts Degrees to Radian
    private double DegreeToRadian(double angle)
    {
       return Math.PI * angle / 180.0;
    }
    double Sin = Math.Sin(DegreeToRadian(double.Parse(TxtBox.Text)));
    PreviousValue = Sin;
    TxtBox.Text = PreviousValue.ToString();
