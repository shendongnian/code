        public string TestCalc(string MilliAmps, string PV_High, string PV_Low)
        {
            double MilliAmps_dbl;
            double PV_High_dbl;
            double PV_Low_dbl;
            double PV_Value_dbl;
            string PV_Value_str;
            MilliAmps_dbl = System.Convert.ToDouble(MilliAmps);
            PV_High_dbl = System.Convert.ToDouble(PV_High);
            PV_Low_dbl = System.Convert.ToDouble(PV_Low);
            PV_Value_dbl = (((MilliAmps_dbl - (double)4) / (double)16) * (PV_High_dbl - PV_Low_dbl)) + PV_Low_dbl;
            PV_Value_str = System.Convert.ToString(PV_Value_dbl);
            return PV_Value_str;
        }
