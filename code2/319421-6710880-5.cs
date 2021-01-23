    var serialValue = 0;
    
    if (!int.TryParse(serialtextbox.Text, out serialValue))
    {
      // Here you would probably present an error to the user stating that the form field failed validation.
      // Maybe even throw an exception?  Depends on how you handle errors.
      // Mainly, exit the logic flow.
      return;
    }
    
    var value = new Item();
    value.features.Add(new ItemFeature { SerialNo = serialValue } );
