    Console.Write("Input Nomor Menu [1..4]: ");
    int pilihan = int.Parse(Console.ReadLine());
    Console.WriteLine();
    if (pilihan > 4 || pilihan < 1)
    {
        Console.WriteLine("Maaf, Menu Yang Anda Pilih Tidak Tersedia"); // Sorry, the Menu You Choose is Not Available
    }
    else
    {    
        Console.Write("Input nilai a = ");
        int a = Convert.ToInt32(Console.ReadLine());
    
        Console.Write("Input nilai b = ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine();
    
    
        switch (pilihan)
        {
            case 1:
                Console.WriteLine("Hasil Penambahan {0} + {1} = {2}", a, b, Penambahan(a, b));
                break;
            case 2:
                Console.WriteLine("Hasil Pengurangan {0} - {1} = {2}", a, b, Pengurangan(a, b));
                break;
            case 3:
                Console.WriteLine("Hasil Perkalian {0} * {1} = {2}", a, b, Perkalian(a, b));
                break;
            case 4:
                Console.WriteLine("Hasil Pembagian {0} / {1} = {2}", a, b, Pembagian(a, b));
                break;
        }
    }
