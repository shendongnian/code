            for (int i = 1; i <= StandardDoor.Count; i++)
            {
                x.Range["E"+i].Value = StandardDoor[i-1];
            }
            for (int i = 1; i <= XDDoor.Count; i++)
            {
                x.Range["F" + i].Value = XDDoor[i - 1];
            }
            for (int i = 1; i <= SR2Door.Count; i++)
            {
                x.Range["G" + i].Value = SR2Door[i - 1];
            }
            for (int i = 1; i <= SR3Door.Count; i++)
            {
                x.Range["H" + i].Value = SR3Door[i - 1];
            }
string xform = "=IF(B2=" + DO.quote + "StandardDoor" + DO.quote + "," 
                + "E1:E4" + ",IF(B2="+ DO.quote + "XDDoor" + DO.quote +"," + "F1: F4" +
                ",IF(B2=" + DO.quote + "SR2Door" + DO.quote + "," 
                + "G1: G3" + ",IF(B2=" + DO.quote + "SR3Door" + DO.quote + "," 
                + "H1: H3" + "," + "I1: I3" + "))))";
x.Range["B4"].Validation.Delete();
x.Range["B4"].Validation.Add(Excel.XlDVType.xlValidateList, 
                 Excel.XlDVAlertStyle.xlValidAlertStop, 
                 Excel.XlFormatConditionOperator.xlBetween, 
                 xform, Type.Missing);
