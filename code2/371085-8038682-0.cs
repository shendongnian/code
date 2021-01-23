    private void validate_ThisAndThat(Object source, ServerValidateEventArgs args)
    {
      CustomValidator thisValidator = (CustomValidator) source;
      string strPeopleEditor = (string)thisValidator.Attributes["peopleEditor"];
      PeopleEditor peopleEditor = (PeopleEditor)panel1.FindControl(strPeopleEditor);
      
      foreach (PickerEntity entity in peopleEditor.ResolvedEntities)
      {
        String tmpPrincipalType = (entity.EntityData["PrincipalType"]).ToString();
    
        if (tmpPrincipalType == "User")
        {
          if ((entity.EntityData["DisplayName"]).ToString().Contains("aString"))
          {
            args.IsValid = false;
          }
        }
      }
    }
