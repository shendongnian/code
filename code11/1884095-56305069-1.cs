    int sum = 0;
    bool isValid = true;
    foreach(var ch in textoconverter)
        if(ListaSubstituicao.TryGet(ch.ToString(), out var value))
            sum += value;
        else
        {
            isValid = false;
            break;
        }
    if(isValid)
        MessageBox.Show($"Sum of found characters is {sum}");
    else
        MessageBox.Show($"Houston we have a problem!");
