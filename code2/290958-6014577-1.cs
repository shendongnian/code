    public class clsFormulaCollection : KeyedCollection<string, clsFormula>
    {
        protected override string GetKeyForItem(clsFormula item)
        {
            return item.Name;
        }
    }
    clsFormulaCollection oFormula = new clsFormulaCollection();
    for (int i = 0; i < 4; i++)
    {
        oFormula.Add(new clsFormula());
    }
    oFormula["FormulaName"].SomeFunction();
