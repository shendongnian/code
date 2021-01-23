    public string Normalize ()
    {
        return Normalization.Normalize (this, 0);
    }
    public string Normalize (NormalizationForm normalizationForm)
    {
        switch (normalizationForm) {
        default:
            return Normalization.Normalize (this, 0);
        case NormalizationForm.FormD:
            return Normalization.Normalize (this, 1);
        case NormalizationForm.FormKC:
            return Normalization.Normalize (this, 2);
        case NormalizationForm.FormKD:
            return Normalization.Normalize (this, 3);
        }
    }
