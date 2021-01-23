            double a, b;
            Console.WriteLine("istenen sayıyı sonuna .00 koyarak yaz");
            a = double.Parse(Console.ReadLine());
            b = a * Math.PI; // Missing colon!
            Console.WriteLine("Sonuç " + b);
