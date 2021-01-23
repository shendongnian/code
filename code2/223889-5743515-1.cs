    protected void Page_Load(object sender, EventArgs e)
    {
    
        if (this.IsPostBack)
        {
            if (ScriptManager1.AsyncPostBackSourceElementID.StartsWith("ctl00$MainContent$calc") && ScriptManager1.AsyncPostBackSourceElementID.EndsWith("$btnRemoveCalculationFromField"))
            {
                //do something on the postback
            }
            else if (ScriptManager1.AsyncPostBackSourceElementID.StartsWith("ctl00$MainContent$calc") && (ScriptManager1.AsyncPostBackSourceElementID.EndsWith("$btnMoveCalculationUp") || ScriptManager1.AsyncPostBackSourceElementID.EndsWith("$btnMoveCalculationDown")))
            {
                //do something on the postback
            }
        }
    
    
        foreach (Calculation calc in calculationCollection)
        {
            AssignedFieldCalculation asCalc = AssignedFieldCalculation.LoadControl(calc);
            asCalc.ID = "calc" + calc.UniqueXKey;
            pnlFieldCalculations.Controls.Add(asCalc);
            
            foreach (Control ct in asCalc.Controls)
            {
                if (ct.ID == "btnMoveCalculationDown" || ct.ID == "btnMoveCalculationUp" || ct.ID == "btnRemoveCalculationFromField")
                {
                    ScriptManager1.RegisterAsyncPostBackControl(ct);
                }
            }
        }
    }
