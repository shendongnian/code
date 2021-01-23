    public virtual bool IsNewFragment(Token token)
    {
        bool isNewFrag = token.EndOffset() >= (fragmentSize * currentNumFrags);
        if (isNewFrag)
        {
            currentNumFrags++;
        }
        
        return isNewFrag;
    }
