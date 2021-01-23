        if (!ValidateB(instanceofB))
        {
            //this should fire, as one of A inside B isn't valid.
            return View(instanceofB);
        }
    ...
    public bool ValidateB(B b)
    {
        foreach (A item in b.Values)
        {
            if (!TryValidateModel(item))
            {
                return false;
            }
        }
        return true; 
    }
