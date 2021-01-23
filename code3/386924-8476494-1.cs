    @helper elementTipificacion(IEnumerable<prueba.Models.Tipificacion> datos)
    {
        foreach (var item in datos)
        {
            if (item.Tipificacion1.Count > 0)
            {
                <li>
                    <a href="#" id="tipificacion-@item.IdTipificacion">
                        @item.Nombre
                    </a>
                    <ul>
                        @elementTipificacion(@item.Tipificacion1)
                    </ul>    
                </li>
            }
            else
            {
                <li>
                    <a href="#" id="tipificacion-@item.IdTipificacion">
                        @item.Nombre
                    </a>
                </li>
            }
        
            datos.ToList().Remove(item); // <!-- not sure the usefulness of this line
            // The .ToList() extension method returns a new list everytime you call it
            // and you don't seem to be doing anything with the result of it, you don't even
            // assign it to a variable
        }
    }
