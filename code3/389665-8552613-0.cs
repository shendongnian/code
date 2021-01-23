    palabrasDataContext dcPalabras = new palabrasDataContext();    //palabrasDataContext would be the name of the DataContext you generated
    Palabras_Definiciones quintanaserena = (from palabras in palabrasDataContext
                                            where palabra == searchInput.Attributes["value"]   //palabra is the name of the column
                                            select palabras).FirstOrDefault();                 //Using firstorDefault here if you have only one definition per word
    
    if(quintanaserena != null)       //FirstorDefault returns null if the resultset was empty
    {
        label1.Text = quintanaserena.definición;
    }
