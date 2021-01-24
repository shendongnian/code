    // use a variable to hold the sum
    int sum = 0;
    // a boolean to hold the result of checking the characters
    bool isValid = true;
    // iterate all characters in the string
    foreach(var ch in textoconverter.ToArray())
        // lookup in dictionary
        if(ListaSubstituicao.TryGet(ch.ToString(), out var value))
            // add the value to sum
            sum += value;
        else
        {
            // the character wasn't found, so the input was invalid
            isValid = false;
            // we need to stop processing
            break;
        }
    // if isValid is true, only valid characters were found.
    if(isValid)
         MessageBox.Show($"Sum of found characters is {sum}");
    else
        MessageBox.Show($"Houston we have a problem!");
