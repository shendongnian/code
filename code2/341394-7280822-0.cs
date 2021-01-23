            double a,b;
            Console.WriteLine("istenen sayıyı sonuna .00 koyarak yaz");
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
                b = a * Math.PI;
                Console.WriteLine("Sonuç " + b); 
            }
            catch (Exception)
            {
                Console.WriteLine("dönüştürme hatası");
                throw;
            }
