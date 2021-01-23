    private void ValidateEffectiveDate()
    {
        bool ICAdvanced = SessionManager.DisplayUser.IsInRole(PERMISSIONS.hasICAdvanced);
        if (!ICAdvanced && model.EffectiveDate < DateTime.Now.Date)
        {
            this.CheckAndAddValidation("EffectiveDate", "You do not have the advanced permission, so you are unable to value historical indications.");
        }
    }
