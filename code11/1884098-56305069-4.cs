    // use a variable to hold the sum
    int sum = 0;
    // iterate all characters in the string
    foreach(var ch in textoconverter.ToArray())
        // lookup in dictionary
        if(ListaSubstituicao.TryGet(ch.ToString(), out var value))
            // add to the sum, when it was found.
            sum += value;
    MessageBox.Show($"Sum of found characters is {sum}");
