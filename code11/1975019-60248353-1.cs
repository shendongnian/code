     public void batch(IEdmVault5 vault5)
    {
        IEdmVault7 edmValult11 = null;
        if (vault5 == null)
        {
               vault5 = new EdmVault5();
        }
        edmVault11 = (IEdmVault11)vault5;
        IEdmBatchRefVars batch = default(IEdmBatchRefVars);
        batch = (IEdmBatchRefVars)edmVault11.CreateUtility(EdmUtility.EdmUtil_BatchRefVars);
        //some code
    }
