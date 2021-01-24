    protected void SetField<T>(ref T field, T value, string propertyName)
        {
           
               if (!EqualityComparer<T>.Default.Equals(field, value))
                {
                    IsDirty = true;
                if ((propertyName == "Comments") && (value != null) && (field != null))
                {
                    
                    var ugField = Uglify.HtmlToText((value as string));
                    var ugValue = Uglify.HtmlToText(field as string);
                    string strField = Regex.Replace(ugField.Code, @"\s+", string.Empty);
                    string strValue = Regex.Replace(ugValue.Code, @"\s+", string.Empty);
                    
                    if (strField == strValue)
                    { IsDirty = false; }
                }
                    field = value;
                    
                    OnPropertyChanged(propertyName);
                }
          
            }
