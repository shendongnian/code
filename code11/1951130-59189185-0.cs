    if (info != null && info.Length >= 5)
    {
        Producto producto = new Producto
        {
            Id = int.Parse(info[0]),
            Nombre = info[1],
            Precio = double.Parse(info[2]),
            Categoria = info[3],
            Detalle = info[4]
        };
        productos.Add(producto);
    }
