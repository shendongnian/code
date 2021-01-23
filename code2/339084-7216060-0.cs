    public Entradas Entrada
    {
        get { return (Entradas)GetValue(EntradaProperty); }
        set 
        { 
            SetValue(EntradaProperty, value); 
            if (Entrada == Entradas.Entero)
                //show button
            else
                //hide button
        }
    }
 
