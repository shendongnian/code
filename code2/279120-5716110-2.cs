    for ( int i = 0; i < n; i++ )
    {
        dst[i] = Complex.Zero;
    
        arg = - (int) direction * 2.0 * System.Math.PI * (double) i / (double) n;
    
        // sum source elements
        for ( int j = 0; j < n; j++ )
        {
            cos = System.Math.Cos( j * arg );
            sin = System.Math.Sin( j * arg );
    
            dst[i].Re += ( data[j].Re * cos - data[j].Im * sin );
            dst[i].Im += ( data[j].Re * sin + data[j].Im * cos );
        }
    }
