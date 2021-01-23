    f[center1_, d_, R1_, R2_] := Module[{Phi, Theta},
        Phi = ArcTan[((Sqrt[d + R1 - R2] Sqrt[d - R1 + R2] 
                      Sqrt[-d + R1 + R2] Sqrt[d + R1 + R2])/(d^2 + R1^2 - R2^2))];
       Theta = ArcTan[((Sqrt[d + R1 - R2] Sqrt[d - R1 + R2] 
                       Sqrt[-d + R1 + R2] Sqrt[d + R1 + R2])/(d^2 - R1^2 + R2^2))];
       {Circle[{center1, 0}, R1, {2 Pi - Phi, Phi}], 
        Circle[{d, 0},       R2, {Pi - Theta, -Pi + Theta}]}
       
       ];
    Graphics[f[0, 1.5, 1, 1]]
