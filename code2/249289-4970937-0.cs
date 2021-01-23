    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) 
    {
      ValidationResult result = null;
      try
        {
            var img = System.Drawing.Image.FromStream(this.ImageFile.InputStream);
            if (img.Width != 200) 
                result = new ValidationResult("This picture isn't the right size!!!!");
        }
        catch (Exception ex)
        {
            result = new ValidationResult("This isn't a real image!") ;
        }
      if (result != null) 
        yield return result;
    }
