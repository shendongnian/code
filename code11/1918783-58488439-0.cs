    for (int y = 0, i = 0; y < 100; y++)
    {
        // for all pixels
        for (int x = 0; x < 100; x++, i++, ptr += 6)
        {
            Neuron neuron = layer.Neurons[i];
    
            // red
            ptr[2] = ptr[2 + 3] = ptr[2 + stride] = ptr[2 + 3 + stride] =
                (byte)Math.Max(0, Math.Min(255, neuron.Weights[0]));
    
            // green
            ptr[1] = ptr[1 + 3] = ptr[1 + stride] = ptr[1 + 3 + stride] =
                (byte)Math.Max(0, Math.Min(255, neuron.Weights[1]));
    
            // blue
            ptr[0] = ptr[0 + 3] = ptr[0 + stride] = ptr[0 + 3 + stride] =
                (byte)Math.Max(0, Math.Min(255, neuron.Weights[2]));
        }
    
        ptr += offset;
        ptr += stride;
    }
 
