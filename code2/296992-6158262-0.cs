    public static class UnitConversion
    {
        public static string[] lstFootUnits = new string[] {"foots", "foot", "feets", "feet", "ft", "f", "\""};
        public static string sFootUnit = "ft";
        public static string[] lstInchUnits = new string[] { "inches", "inchs", "inch", "in", "i", "\'" };
        public static string sInchUnit = "in";
        public static string[] lstPoundUnits = new string[] { "pounds", "pound", "pnds", "pnd", "lbs", "lb", "l", "p" };
        public static string sPoundUnit = "lbs";
        public static string[] lstOunceUnits = new string[] { "ounces", "ounce", "ozs", "oz", "o" };
        public static string sOunceUnit = "oz";
        public static string[] lstCentimeterUnits = new string[] { "centimeters", "centimeter", "centimetres", "centimetre", "cms", "cm", "c"};
        public static string sCentimeterUnit = "cm";
        public static string[] lstKilogramUnits = new string[] { "kilograms", "kilogram", "kilos", "kilo", "kgs", "kg", "k" };
        public static string sKilogramsUnit = "kgs";
        /// <summary>
        /// Attempt to convert between feet/inches and cm
        /// </summary>
        /// <param name="sHeight"></param>
        /// <returns></returns>
        public static string ConvertHeight(string sHeight)
        {
            if (!String.IsNullOrEmpty(sHeight))
            {
                sHeight = UnitConversion.CleanHeight(sHeight);
                if (sHeight.Contains(UnitConversion.sFootUnit))
                {
                    sHeight = sHeight.Replace(UnitConversion.sFootUnit, "|");
                    sHeight = sHeight.Replace(UnitConversion.sInchUnit, "|");
                    string[] sParts = sHeight.Split('|');
                    double? dFeet = null;
                    double? dInches = null;
                    double dFeetParsed;
                    double dInchesParsed;
                    if (sParts.Length >= 2 && double.TryParse(sParts[0].Trim(), out dFeetParsed))
                    {
                        dFeet = dFeetParsed;
                    }
                    if (sParts.Length >= 4 && double.TryParse(sParts[2].Trim(), out dInchesParsed))
                    {
                        dInches = dInchesParsed;
                    };
                    sHeight = UnitConversion.FtToCm(UnitConversion.CalculateFt(dFeet ?? 0, dInches ?? 0)).ToString() + " " + UnitConversion.sCentimeterUnit;
                }
                else if (sHeight.Contains(UnitConversion.sCentimeterUnit))
                {
                    sHeight = sHeight.Replace(UnitConversion.sCentimeterUnit, "|");
                    string[] sParts = sHeight.Split('|');
                    double? dCentimeters = null;
                    double dCentimetersParsed;
                    if (sParts.Length >= 2 && double.TryParse(sParts[0].Trim(), out dCentimetersParsed))
                    {
                        dCentimeters = dCentimetersParsed;
                    }
                    int? iFeet;
                    int? iInches;
                    if (UnitConversion.CmToFt(dCentimeters, out iFeet, out iInches))
                    {
                        sHeight = (iFeet != null) ? iFeet.ToString() + " " + UnitConversion.sFootUnit : "";
                        sHeight += (iInches != null) ? " " + iInches.ToString() + " " + UnitConversion.sInchUnit : "";
                        sHeight = sHeight.Trim();
                    }
                    else
                    {
                        sHeight = "";
                    }
                }
                else
                {
                    sHeight = "";
                }
            }
            else
            {
                sHeight = "";
            }
            return sHeight;
        }
        /// <summary>
        /// Attempt to convert between Kgs and Lbs
        /// </summary>
        /// <param name="sWeight"></param>
        /// <returns></returns>
        public static string ConvertWeight(string sWeight)
        {
            if (!String.IsNullOrEmpty(sWeight))
            {
                sWeight = UnitConversion.CleanWeight(sWeight);
                if (sWeight.Contains(UnitConversion.sKilogramsUnit))
                {
                    sWeight = sWeight.Replace(UnitConversion.sKilogramsUnit, "|");
                    string[] sParts = sWeight.Split('|');
                    double? dKilograms = null;
                    double dKilogramsParsed;
                    if (sParts.Length >= 2 && double.TryParse(sParts[0].Trim(), out dKilogramsParsed))
                    {
                        dKilograms = dKilogramsParsed;
                    }
                    sWeight = UnitConversion.KgToLbs(dKilograms).ToString("#.###") + " " + UnitConversion.sPoundUnit;
                }
                else if (sWeight.Contains(UnitConversion.sPoundUnit))
                {
                    sWeight = sWeight.Replace(UnitConversion.sPoundUnit, "|");
                    string[] sParts = sWeight.Split('|');
                    double? dPounds = null;
                    double dPoundsParsed;
                    if (sParts.Length >= 2 && double.TryParse(sParts[0].Trim(), out dPoundsParsed))
                    {
                        dPounds = dPoundsParsed;
                    }
                    sWeight = UnitConversion.LbsToKg(dPounds).ToString("#.###") + " " + UnitConversion.sKilogramsUnit;
                }
                else
                {
                    sWeight = "";
                }
            }
            else
            {
                sWeight = "";
            }
            return sWeight;
        }
        public static double? CalculateFt(double dFt, double dInch)
        {
            double? dFeet = null;
            if (dFt >= 0 && dInch >= 0 && dInch <= 12)
            {
                dFeet = dFt + (dInch / 12);
            }
            return dFeet;
        }
        public static double KgToLbs(double? dKg)
        {
            if (dKg == null)
            {
                return 0;
            }
            return dKg.Value * 2.20462262;
        }
        public static double LbsToKg(double? dLbs)
        {
            if (dLbs == null)
            {
                return 0;
            }
            return dLbs.Value / 2.20462262;
        }
        public static double FtToCm(double? dFt)
        {
            if (dFt == null)
            {
                return 0;
            }
            return dFt.Value * 30.48;
        }
        public static bool CmToFt(double? dCm, out int? iFt, out int? iInch)
        {
            if (dCm == null)
            {
                iFt = null;
                iInch = null;
                return false;
            }
            double dCalcFeet = dCm.Value / 30.48;
            double dCalcInches = dCalcFeet - Math.Floor(dCalcFeet);
            dCalcFeet = Math.Floor(dCalcFeet);
            dCalcInches = dCalcInches * 12;
            iFt = (int)dCalcFeet;
            iInch = (int)dCalcInches;
            return true;
        }
        private static string CleanUnit(string sOriginal, string[] lstReplaceUnits, string sReplaceWithUnit)
        {
            System.Text.StringBuilder sbPattern = new System.Text.StringBuilder();
            foreach (string sReplace in lstReplaceUnits)
            {
                if (sbPattern.Length > 0)
                {
                    sbPattern.Append("|");
                }
                sbPattern.Append(sReplace);
            }
            sbPattern.Insert(0,@"(^|\s)(");
            sbPattern.Append(@")(\s|$)");
            
            System.Text.RegularExpressions.Regex rReplace = new System.Text.RegularExpressions.Regex(sbPattern.ToString(), System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                
            sOriginal = rReplace.Replace(sOriginal, sReplaceWithUnit);
            /*foreach (string sReplace in lstReplaceUnits)
            {
                
                sOriginal = sOriginal.Replace(sReplace, " " + sReplaceWithUnit);
            }*/
             
            return sOriginal;
        }
        private static bool StringHasNumbers(string sText)
        {
            System.Text.RegularExpressions.Regex rxNumbers = new System.Text.RegularExpressions.Regex("[0-9]+");
            return rxNumbers.IsMatch(sText);
        }
        private static string ReduceSpaces(string sText)
        {
            while (sText.Contains("  "))
            {
                sText = sText.Replace("  ", " ");
            }
            return sText;
        }
        private static string SeperateNumbers(string sText)
        {
            bool bNumber = false;
            if (!String.IsNullOrEmpty(sText))
            {
                for (int iChar = 0; iChar < sText.Length; iChar++)
                {
                    bool bIsNumber = (sText[iChar] >= '0' && sText[iChar] <= '9') || 
                        (sText[iChar] == '.' && iChar < sText.Length - 1 && sText[iChar + 1] >= '0' && sText[iChar + 1] <= '9');
                    if (iChar > 0 && bIsNumber != bNumber)
                    {
                        sText = sText.Insert(iChar, " ");
                        iChar++;
                    }
                    bNumber = bIsNumber;
                }
            }
            return sText;
        }
        public static string CleanHeight(string sHeight)
        {
            if (UnitConversion.StringHasNumbers(sHeight))
            {
                sHeight = SeperateNumbers(sHeight);
                sHeight = CleanUnit(sHeight, UnitConversion.lstFootUnits, UnitConversion.sFootUnit);
                sHeight = CleanUnit(sHeight, UnitConversion.lstInchUnits, UnitConversion.sInchUnit);
                sHeight = CleanUnit(sHeight, UnitConversion.lstCentimeterUnits, UnitConversion.sCentimeterUnit);
                sHeight = SeperateNumbers(sHeight);
                sHeight = ReduceSpaces(sHeight);
            }
            else
            {
                sHeight = "";
            }
            return sHeight;
        }
        public static string CleanWeight(string sWeight)
        {
            if (UnitConversion.StringHasNumbers(sWeight))
            {
                sWeight = SeperateNumbers(sWeight);
                sWeight = CleanUnit(sWeight, UnitConversion.lstOunceUnits, UnitConversion.sOunceUnit);
                sWeight = CleanUnit(sWeight, UnitConversion.lstPoundUnits, UnitConversion.sPoundUnit);
                sWeight = CleanUnit(sWeight, UnitConversion.lstKilogramUnits, UnitConversion.sKilogramsUnit);
                sWeight = SeperateNumbers(sWeight);
                sWeight = ReduceSpaces(sWeight);
            }
            else
            {
                sWeight = "";
            }
            return sWeight;
        }
    }
