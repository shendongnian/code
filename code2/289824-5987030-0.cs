    float f = 0.3f;
    double d1 = System.Convert.ToDouble(f);
    double d2 = System.Convert.ToDouble(f.ToString("G20"));
    
    string s = string.Format("d1 : {0} ; d2 : {1} ", d1, d2);
