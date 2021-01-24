    public string ValidateManagerName()
    {
       if (string.IsNullOrEmpty(this.ProjectManager))
            {
                return "string.Empty";
            }
            //Other conditions can be written like alphanumeric cherck
            else
                return string.Empty;
        }
