    partial void OnValidate(ChangeAction action)
    {
        if (this.UpdatedOn < (DateTime)SqlDateTime.MinValue)
            this.UpdatedOn = (DateTime)SqlDateTime.MinValue;
    }
