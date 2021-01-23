    public int GetBaseField()
    {
        return base.Field; // calls Base.get_Field(), which uses the base
                           // class's auto-generated backing property
    }
