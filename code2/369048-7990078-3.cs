    private double CalcUpAdj(AccelerometerReading reading)
    {
        double angle = PhoneUtilities.Utilities.AccelerometerMath.Yaw(reading);
        //Get the angleNeeded for calculation
        double angleNeeded = Math.Abs(angle);
        double adj = CalcAdj(angleNeeded);
        tbAngle.Text = String.Format("{0:0.00}", angleNeeded) + (char)176;
        textBlockAdj.Text = adj.ToString();
        return adj;
    }
    private double CalcAdj(double angleNeeded)
    {
        double number;
        if (double.TryParse(tbHyp.Text, out number))
        {
            double hyp = number;
            double adj = Math.Cos(Math.PI * angleNeeded / 180) * hyp;
            tbAngle.Text = String.Format("{0:0.00}", angleNeeded) + (char)176;
            textBlockAdj.Text = adj.ToString();
            return adj;
        }
        return 0;
    }
